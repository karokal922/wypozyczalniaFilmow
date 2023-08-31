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
    public class RatesController : Controller
    {
        private IUnitOfWork unitOfWork;

        public RatesController(MovieRentalContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        // GET: Rates
        public IActionResult Index()
        {
            var rates = unitOfWork.RateRepository.GetRates();
            return View(rates.ToList());
        }

        // GET: Rates/Details/5
        public IActionResult Details(int id)
        {
            if (id == null || unitOfWork.RateRepository.GetRates() == null)
            {
                return NotFound();
            }

            var rate = unitOfWork.RateRepository.GetRate(id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // GET: Rates/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(unitOfWork.MovieRepository.GetMovies(), "Id_Movie", "Title");
            ViewData["UserId"] = new SelectList(unitOfWork.UserRepository.GetUsers(), "Id_User", "Name");
            return View();
        }

        // POST: Rates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Rate rate)
        {
            ModelState.Remove("User");
            ModelState.Remove("Movie");
            if (ModelState.IsValid)
            {
                unitOfWork.RateRepository.InsertRate(rate);
                unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MovieId"] = new SelectList(unitOfWork.MovieRepository.GetMovies(), "Id_Movie", "Title", rate.MovieId);
            ViewData["UserId"] = new SelectList(unitOfWork.UserRepository.GetUsers(), "Id_User", "Name", rate.UserId);
            return View(rate);
        }

        // GET: Rates/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null || unitOfWork.RateRepository.GetRates() == null)
            {
                return NotFound();
            }

            var rate = unitOfWork.RateRepository.GetRate(id);
            if (rate == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(unitOfWork.MovieRepository.GetMovies(), "Id_Movie", "Title", rate.MovieId);
            ViewData["UserId"] = new SelectList(unitOfWork.UserRepository.GetUsers(), "Id_User", "Name", rate.UserId);
            return View(rate);
        }

        // POST: Rates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Rate rate)
        {
            if (id != rate.Id_Rate)
            {
                return NotFound();
            }
            ModelState.Remove("User");
            ModelState.Remove("Movie");
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.RateRepository.UpdateRate(rate);
                    unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RateExists(rate.Id_Rate))
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
            ViewData["MovieId"] = new SelectList(unitOfWork.MovieRepository.GetMovies(), "Id_Movie", "Director", rate.MovieId);
            ViewData["UserId"] = new SelectList(unitOfWork.UserRepository.GetUsers(), "Id_User", "Name", rate.UserId);
            return View(rate);
        }

        // GET: Rates/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null || unitOfWork.RateRepository.GetRates() == null)
            {
                return NotFound();
            }

            var rate = unitOfWork.RateRepository.GetRate(id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (unitOfWork.RateRepository.GetRates() == null)
            {
                return Problem("Entity set 'MovieRentalContext.Ratings'  is null.");
            }
            var rate = unitOfWork.RateRepository.GetRate(id);
            if (rate != null)
            {
                unitOfWork.RateRepository.DeleteRate(rate.Id_Rate);
            }
            
            unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool RateExists(int id)
        {
          return (unitOfWork.RateRepository.GetRates()?.Any(e => e.Id_Rate == id)).GetValueOrDefault();
        }
    }
}
