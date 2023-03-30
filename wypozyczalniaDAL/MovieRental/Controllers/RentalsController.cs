using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;

namespace MovieRental.Controllers
{
    public class RentalsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Rentals
        public ActionResult Index()
        {
            var rentals = unitOfWork.RentRepository.Get(includeProperties: "Movies");
            return View(rentals.ToList());
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            Rent rent = unitOfWork.RentRepository.GetByID(id);
            return View(rent);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id_Rate,Payment_ID,User_ID,RentingDate")] Rent rent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.RentRepository.Insert(rent);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(rent);
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            Rent rent = unitOfWork.RentRepository.GetByID(id);
            return View(rent);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Rent rent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.RentRepository.Update(rent);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(rent);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            Rent rent = unitOfWork.RentRepository.GetByID(id);
            return View(rent);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rent rent = unitOfWork.RentRepository.GetByID(id);
            unitOfWork.RentRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        //private bool RentExists(int id)
        //{
        //  return (_context.Rentals?.Any(e => e.Id_Rate == id)).GetValueOrDefault();
        //}
    }
}
