using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using MovieRental.DAL.Repositories;

namespace MovieRental.MVC.Controllers
{
    public class UsersController : Controller
    {
        private IUnitOfWork unitOfWork;

        public UsersController(MovieRentalContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        // GET: Users
        public IActionResult Index()
        {
            var users = unitOfWork.UserRepository.GetUsers();
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public IActionResult Details(int id)
        {
            if (id == null || unitOfWork.UserRepository.GetUsers() == null)
            {
                return NotFound();
            }

            var user = unitOfWork.UserRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            ModelState.Remove("Rates");
            ModelState.Remove("Rents");
            if (ModelState.IsValid)
            {
                unitOfWork.UserRepository.InsertUser(user);
                unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null || unitOfWork.UserRepository.GetUsers() == null)
            {
                return NotFound();
            }

            var user = unitOfWork.UserRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User user)
        {
            if (id != user.Id_User)
            {
                return NotFound();
            }

            ModelState.Remove("Rates");
            ModelState.Remove("Rents");
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.UserRepository.UpdateUser(user);
                    unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id_User))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null || unitOfWork.UserRepository.GetUsers() == null)
            {
                return NotFound();
            }

            var user = unitOfWork.UserRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (unitOfWork.UserRepository.GetUsers() == null)
            {
                return Problem("Entity set 'MovieRentalContext.Users'  is null.");
            }
            var user = unitOfWork.UserRepository.GetUser(id);
            if (user != null)
            {
                unitOfWork.UserRepository.DeleteUser(user.Id_User);
            }
            
            unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (unitOfWork.UserRepository.GetUsers()?.Any(e => e.Id_User == id)).GetValueOrDefault();
        }
    }
}
