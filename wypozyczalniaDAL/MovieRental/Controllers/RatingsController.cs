using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;

namespace MovieRental.Controllers
{
    public class RatingsController : Controller
    {
        //private UnitOfWork unitOfWork = new UnitOfWork();
        private IUnitOfWork unitOfWork;// = new UnitOfWork();

        public RatingsController(MovieRentalContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        // GET: Ratings
        public ActionResult Index()
        {
            var ratings = unitOfWork.RateRepository.GetRates();//Get(includeProperties: "");
            return View(ratings.ToList());
        }

        // GET: Ratings/Details/5
        public ActionResult Details(int id)
        {
            Rate rate = unitOfWork.RateRepository.GetRate(id);//GetByID(id);
            return View(rate);
        }

        // GET: Ratings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rate rate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.RateRepository.InsertRate(rate);//Insert(rate);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(rate);
        }

        // GET: Ratings/Edit/5
        public ActionResult Edit(int id)
        {
            Rate rate = unitOfWork.RateRepository.GetRate(id);//GetByID(id);
            return View(rate);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Rate rate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.RateRepository.UpdateRate(rate);//Update(rate);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(rate);
        }

        // GET: Ratings/Delete/5
        public ActionResult Delete(int id)
        {
            Rate rate = unitOfWork.RateRepository.GetRate(id); //GetByID(id);
            return View(rate);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rate rate = unitOfWork.RateRepository.GetRate(id); //GetByID(id);
            unitOfWork.RateRepository.DeleteRate(id);//Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        //private bool RateExists(int id)
        //{
        //  return (_context.Ratings?.Any(e => e.Id_Rate == id)).GetValueOrDefault();
        //}
    }
}
