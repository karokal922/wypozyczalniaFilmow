using System;
using System.Collections.Generic;
using System.Drawing;
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
    public class CategoriesController : Controller
    {
        private IUnitOfWork unitOfWork;

        public CategoriesController(MovieRentalContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        // GET: Categories
        public IActionResult Index()
        {
            var categories = unitOfWork.CategoryRepository.GetCategories();
            return View(categories.ToList());
        }

        // GET: Categories/Details/5
        public IActionResult Details(int id)
        {
            if (id == null || unitOfWork.CategoryRepository.GetCategories() == null)
            {
                return NotFound();
            }

            var category = unitOfWork.CategoryRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            //var movies = unitOfWork.MovieRepository.GetMovies();
            //ViewData["MovieId"] = new SelectList(movies, "Id_Movie", "Id_Movie");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            unitOfWork.CategoryRepository.InsertCategory(category);
            unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null || unitOfWork.CategoryRepository.GetCategories() == null)
            {
                return NotFound();
            }

            var category = unitOfWork.CategoryRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            if (id != category.Id_Category)
            {
                return NotFound();
            }
            try
            {
                unitOfWork.CategoryRepository.UpdateCategory(category);
                unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.Id_Category))
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

        // GET: Categories/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null || unitOfWork.CategoryRepository.GetCategories() == null)
            {
                return NotFound();
            }

            var category = unitOfWork.CategoryRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (unitOfWork.CategoryRepository.GetCategories() == null)
            {
                return Problem("Entity set 'MovieRentalContext.Categories'  is null.");
            }
            var category = unitOfWork.CategoryRepository.GetCategory(id);
            if (category != null)
            {
                unitOfWork.CategoryRepository.DeleteCategory(category.Id_Category);
            }
            
            unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return (unitOfWork.CategoryRepository.GetCategories()?.Any(e => e.Id_Category == id)).GetValueOrDefault();
        }
    }
}
