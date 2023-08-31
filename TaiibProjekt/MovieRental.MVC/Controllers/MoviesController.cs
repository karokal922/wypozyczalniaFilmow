using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using MovieRental.DAL.Repositories;
using NuGet.Packaging;

namespace MovieRental.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private IUnitOfWork unitOfWork;

        public MoviesController(MovieRentalContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        // GET: Movies
        public IActionResult Index()
        {
            var movies = unitOfWork.MovieRepository.GetMovies();
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public IActionResult Details(int id)
        {
            if (id == null || unitOfWork.MovieRepository.GetMovies() == null)
            {
                return NotFound();
            }

            var movie = unitOfWork.MovieRepository.GetMovie(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            var rentList = new SelectList(unitOfWork.RentRepository.GetRents(), "Id_Rent", "Id_Rent");

            var defaultOption = new SelectListItem
            {
                Value = "",
                Text = "- none -" 
            };
            ViewData["RentId"] = new SelectList(rentList.Concat(new[] { defaultOption }), "Value", "Text", selectedValue: "");
            ViewData["Categories"] = new MultiSelectList(unitOfWork.CategoryRepository.GetCategories(), "Id_Category", "CategoryName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if(movie.CategoriesIds == null || movie.CategoriesIds.Count() < 1)
            {
                ViewData["NotificationMessage"] = "No category selected.";
                var rentList = new SelectList(unitOfWork.RentRepository.GetRents(), "Id_Rent", "Id_Rent");
                
                var defaultOption = new SelectListItem
                {
                    Value = "",
                    Text = "- none -"
                };
                ViewData["RentId"] = new SelectList(rentList.Concat(new[] { defaultOption }), "Value", "Text", selectedValue: "");
                ViewData["Categories"] = new MultiSelectList(unitOfWork.CategoryRepository.GetCategories(), "Id_Category", "CategoryName");
                return View(movie);
            }
            var categories = unitOfWork.CategoryRepository.GetCategories()
                .Where(c => movie.CategoriesIds.Contains(c.Id_Category));
            movie.Categories = categories.ToList();
            unitOfWork.MovieRepository.InsertMovie(movie);
            unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null || unitOfWork.MovieRepository.GetMovies() == null)
            {
                return NotFound();
            }
            var movie = unitOfWork.MovieRepository.GetMovie(id);
            var movieModel = new MovieEditViewModel
            {
                MovieId = movie.Id_Movie,
                RentId = movie.RentId,
                Description = movie.Description,
                Title = movie.Title,
                Director = movie.Director,
                Premiere = movie.Premiere,
            };
            if (movie == null)
            {
                return NotFound();
            }

            var rentList = new SelectList(unitOfWork.RentRepository.GetRents(), "Id_Rent", "Id_Rent");
            var defaultOption = new SelectListItem
            {
                Value = "",
                Text = "- none -"
            };
            ViewData["RentId"] = new SelectList(rentList.Concat(new[] { defaultOption }), "Value", "Text", selectedValue: "");
            ViewData["Categories"] = new MultiSelectList(unitOfWork.CategoryRepository.GetCategories(), "Id_Category", "CategoryName");
            return View(movieModel);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MovieEditViewModel movieModel)
        {
            var movie = unitOfWork.MovieRepository.GetMovie(id);
            if (id != movie.Id_Movie)
            {
                return NotFound();
            }

            ModelState.Remove("Rent");
            ModelState.Remove("Rates");
            ModelState.Remove("Categories");
            ModelState.Remove("CategoriesIds");
            if (ModelState.IsValid && movieModel.SelectedCategoriesIds != null && movieModel.SelectedCategoriesIds.Count() > 0)
            {
                try
                {
                    var categories = unitOfWork.CategoryRepository.GetCategories().Where(c => movieModel.SelectedCategoriesIds.Contains(c.Id_Category));
                    movie.Categories = categories.ToList();
                    movie.CategoriesIds = movieModel.SelectedCategoriesIds;
                    movie.Title = movieModel.Title;
                    movie.Description = movieModel.Description;
                    movie.Director = movieModel.Director;
                    movie.Premiere = movieModel.Premiere;
                    movie.RentId = movieModel.RentId;
                    movie.Rent = (movieModel.RentId != null) ? unitOfWork.RentRepository.GetRent((int)movieModel.RentId) : null;
                    unitOfWork.MovieRepository.UpdateMovie(movie);
                    unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id_Movie))
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

            var rentList = new SelectList(unitOfWork.RentRepository.GetRents(), "Id_Rent", "Id_Rent");
            var defaultOption = new SelectListItem
            {
                Value = "",
                Text = "- none -"
            };
            ViewData["NotificationMessage"] = "No category selected.";
            ViewData["RentId"] = new SelectList(rentList.Concat(new[] { defaultOption }), "Value", "Text", selectedValue: "");
            ViewData["Categories"] = new MultiSelectList(unitOfWork.CategoryRepository.GetCategories(), "Id_Category", "CategoryName");
            return View(movieModel);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null || unitOfWork.MovieRepository.GetMovies() == null)
            {
                return NotFound();
            }

            var movie = unitOfWork.MovieRepository.GetMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (unitOfWork.MovieRepository.GetMovies() == null)
            {
                return Problem("Entity set 'MovieRentalContext.Movies'  is null.");
            }
            var movie = unitOfWork.MovieRepository.GetMovie(id);
            if (movie != null)
            {
                unitOfWork.MovieRepository.DeleteMovie(movie.Id_Movie); 
            }

            unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return (unitOfWork.MovieRepository.GetMovies()?.Any(e => e.Id_Movie == id)).GetValueOrDefault();
        }
    }
    public class MovieEditViewModel
    {
        public int MovieId { get; set; }
        public List<int> SelectedCategoriesIds { get; set; }
        public int? RentId { get; set; }

        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public DateTime Premiere { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
    }
}
