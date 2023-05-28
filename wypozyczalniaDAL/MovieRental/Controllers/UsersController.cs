using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRentalBLL.Interfaces;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;


namespace MovieRental.Controllers
{
    public class UsersController : Controller
    {
        //private UnitOfWork unitOfWork = new UnitOfWork();
        private IUnitOfWork unitOfWork;// = new UnitOfWork();

        public UsersController(MovieRentalContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        // GET: Users
        public ActionResult Index()
        {
            var users = unitOfWork.UserRepository.GetUsers();//Get(includeProperties: "Rates");
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)//int?
        {
            User user = unitOfWork.UserRepository.GetUser(id);//GetByID(id);
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
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.UserRepository.InsertUser(user);//Insert(user);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            User user = unitOfWork.UserRepository.GetUser(id);//GetByID(id);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.UserRepository.UpdateUser(user);//Update(user);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            User user = unitOfWork.UserRepository.GetUser(id);//GetByID(id);
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = unitOfWork.UserRepository.GetUser(id); //GetByID(id);
            unitOfWork.UserRepository.DeleteUser(id);//Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        //private bool UserExists(int id)
        //{
        //  return (_context.Users?.Any(e => e.Id_User == id)).GetValueOrDefault();
        //}
    }
}
