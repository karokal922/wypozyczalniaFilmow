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
        private readonly MovieRentalContext _context;


        private IUnitOfWork unitOfWork;// = new UnitOfWork();

        public MoviesController(MovieRentalContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }


        // GET: Movies
        public IActionResult Index()
        {
            var movies = unitOfWork.MovieRepository.GetMovies();//Get(includeProperties: "Movies");
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public IActionResult Details(int id)
        {
            Movie movie = unitOfWork.MovieRepository.GetMovie(id);//GetByID(id);
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
        public  IActionResult Create([Bind("Title,Director,Premiere,Description")] Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.MovieRepository.InsertMovie(movie);
                    unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int id)
        {
            Movie movie = unitOfWork.MovieRepository.GetMovie(id); //GetByID(id);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id_Movie,Title,Director,Premiere,Description")] Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.MovieRepository.UpdateMovie(movie);//Update(rent);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(int id)
        {
            Movie movie = unitOfWork.MovieRepository.GetMovie(id); //GetByID(id);
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Movie movie = unitOfWork.MovieRepository.GetMovie(id); //GetByID(id);
            unitOfWork.MovieRepository.DeleteMovie(id);//Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        private bool MovieExists(int id)
        {
          return (_context.Movies?.Any(e => e.Id_Movie == id)).GetValueOrDefault();
        }
    }
}
