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
    public class MoviesController : Controller
    {

        //private UnitOfWork unitOfWork = new UnitOfWork();
        private IUnitOfWork unitOfWork;// = new UnitOfWork();

        public MoviesController(MovieRentalContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = unitOfWork.MovieRepository.Get(includeProperties: "Categories");
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            Movie movie = unitOfWork.MovieRepository.GetByID(id);
            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.MovieRepository.Insert(movie);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateDepartmentsDropDownList(movie.Id_Movie);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            Movie movie = unitOfWork.MovieRepository.GetByID(id);
            PopulateDepartmentsDropDownList(movie.Id_Movie);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.MovieRepository.Update(movie);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateDepartmentsDropDownList(movie.Id_Movie);
            return View(movie);
        }

        
        private void PopulateDepartmentsDropDownList(object selectedCategory = null)
        {
            var categoriesQuary = unitOfWork.CategoryRepository.Get(
                orderBy: q => q.OrderBy(d => d.Id_Category));
            ViewBag.Id_Category = new SelectList(categoriesQuary, "Id_Category", "Id_Category", selectedCategory);
        }

        //
        // GET: /Course/Delete/5

        public ActionResult Delete(int id)
        {
            Movie movie = unitOfWork.MovieRepository.GetByID(id);
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = unitOfWork.MovieRepository.GetByID(id);
            unitOfWork.MovieRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}
