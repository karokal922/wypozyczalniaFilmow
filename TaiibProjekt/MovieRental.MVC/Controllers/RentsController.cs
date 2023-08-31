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
    public class RentsController : Controller
    {
        private IUnitOfWork unitOfWork;

        public RentsController(MovieRentalContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        // GET: Rents
        public IActionResult Index()
        {
            var rents = unitOfWork.RentRepository.GetRents();
            return View(rents.ToList());
        }

        // GET: Rents/Details/5
        public IActionResult Details(int id)
        {
            if (id == null || unitOfWork.RentRepository.GetRents() == null)
            {
                return NotFound();
            }

            var rent = unitOfWork.RentRepository.GetRent(id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // GET: Rents/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(unitOfWork.UserRepository.GetUsers(), "Id_User", "Name");
            //ViewData["PaymentId"] = new SelectList(unitOfWork.PaymentRepository.GetPayments(), "Id_Payment", "Id_Payment");
            ViewData["MoviesIds"] = new MultiSelectList(unitOfWork.MovieRepository.GetMovies().Where(m => m.RentId == null), "Id_Movie", "Title");//displays only available movies 
            return View();
        }

        // POST: Rents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Rent rent)
        {
            ModelState.Remove("Payment");
            ModelState.Remove("User");
            ModelState.Remove("Movies");
            ModelState.Remove("MoviesIds");
            if (ModelState.IsValid && rent.MoviesIds != null && rent.MoviesIds.Count() > 0)
            {
                var movies = unitOfWork.MovieRepository.GetMovies()
                    .Where(m => rent.MoviesIds.Contains(m.Id_Movie));
                rent.Movies = movies.ToList();
                unitOfWork.RentRepository.InsertRent(rent);
                unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NotificationMessage"] = "No movie selected.";
            //ViewData["PaymentId"] = new SelectList(unitOfWork.PaymentRepository.GetPayments(), "Id_Payment", "Id_Payment");
            ViewData["MoviesIds"] = new MultiSelectList(unitOfWork.MovieRepository.GetMovies().Where(m => m.RentId == null), "Id_Movie", "Title");//displays only available movies 
            ViewData["UserId"] = new SelectList(unitOfWork.UserRepository.GetUsers(), "Id_User", "Name");
            return View(rent);
        }

        // GET: Rents/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null || unitOfWork.RentRepository.GetRents() == null)
            {
                return NotFound();
            }

            var rent = unitOfWork.RentRepository.GetRent(id);
            var rentModel = new RentEditViewModel { RentId = rent.Id_Rent, RentingDate = rent.RentingDate, UserId = rent.UserId };
            if (rent == null)
            {
                return NotFound();
            }
            ViewData["MoviesIds"] = new MultiSelectList(unitOfWork.MovieRepository.GetMovies().Where(m => m.RentId == null || m.RentId == id), "Id_Movie", "Title");
            ViewData["UserId"] = new SelectList(unitOfWork.UserRepository.GetUsers(), "Id_User", "Name", rent.UserId);
            return View(rentModel);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RentEditViewModel rentModel)
        {
            var rent = unitOfWork.RentRepository.GetRent(id);

            if (id != rent.Id_Rent)
            {
                return NotFound();
            }

            ModelState.Remove("Payment");
            ModelState.Remove("User");
            ModelState.Remove("Movies");
            ModelState.Remove("MoviesIds");
            if (ModelState.IsValid && rentModel.SelectedMovieIds != null && rentModel.SelectedMovieIds.Count() > 0)
            {
                try
                {
                    var movies = unitOfWork.MovieRepository.GetMovies().Where(m => rentModel.SelectedMovieIds.Contains(m.Id_Movie)).ToList();
                    rent.Movies = movies;
                    rent.MoviesIds = rentModel.SelectedMovieIds;
                    rent.RentingDate = rentModel.RentingDate;
                    rent.UserId = rentModel.UserId;
                    rent.User = unitOfWork.UserRepository.GetUser(rentModel.UserId);
                    unitOfWork.RentRepository.UpdateRent(rent);
                    unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentExists(rent.Id_Rent))
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
            ViewData["NotificationMessage"] = "No movie selected.";
            ViewData["MoviesIds"] = new MultiSelectList(unitOfWork.MovieRepository.GetMovies().Where(m => m.RentId == null || m.RentId == id), "Id_Movie", "Title");//displays only available movies 
            ViewData["UserId"] = new SelectList(unitOfWork.UserRepository.GetUsers(), "Id_User", "Name", rentModel.UserId);
            return View(rentModel);
        }

        // GET: Rents/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null || unitOfWork.RentRepository.GetRents() == null)
            {
                return NotFound();
            }

            var rent = unitOfWork.RentRepository.GetRent(id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (unitOfWork.RentRepository.GetRents() == null)
            {
                return Problem("Entity set 'MovieRentalContext.Rentals'  is null.");
            }
            var rent = unitOfWork.RentRepository.GetRent(id);
            if (rent != null)
            {
               unitOfWork.RentRepository.DeleteRent(rent.Id_Rent);
            }

            unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool RentExists(int id)
        {
          return (unitOfWork.RentRepository.GetRents()?.Any(e => e.Id_Rent == id)).GetValueOrDefault();
        }
    }
    public class RentEditViewModel
    {
        public int RentId { get; set; }
        public List<int> SelectedMovieIds { get; set; }
        public int UserId { get; set; }
        public DateTime RentingDate { get; set; }
    }
}
