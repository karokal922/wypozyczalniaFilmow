using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieRental.BLL.Interfaces;
using MovieRental.DAL.Models;
using MovieRental.DAL.Repositories;

namespace MovieRental.BLL.MVC.Controllers
{
    public class RentController : Controller
    {
        private readonly IRentService rentService;

        public RentController(IRentService rentService)
        {
            this.rentService = rentService;
        }
        public IActionResult Index()
        {
            ViewBag.AllUsers = rentService.GetAllUsers();
            ViewBag.AllMovies = rentService.GetAllMovies();
            return View();
        }

        public IActionResult GetRentalsByMovie(int id)
        {
            ViewBag.RentalsByMovie = rentService.GetRentalsByMovie(id);
            return View("RentalsByMovie");
        }
        public IActionResult GetRentalsByUser(int id)
        {
            ViewBag.RentalsByUser = rentService.GetRentalsByUser(id);
            return View("RentalsByUser");
        }
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(rentService.GetAllUsers(), "Id_User", "Name", "Surname");
            ViewData["MoviesIds"] = new MultiSelectList(rentService.GetAllMovies().Where(m => m.RentId == null), "Id_Movie", "Title");//displays only available movies 
            return View("Create");
        }
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
                var movies = rentService.GetAllMovies().Where(m => rent.MoviesIds.Contains(m.Id_Movie));
                var user = rentService.GetAllUsers().Where(u => u.Id_User == rent.UserId).FirstOrDefault();
                if (movies.Count() > 0 && user != null)
                {
                    rent.Movies = movies.ToList();
                    rent.User = user;
                    int? result = rentService.CreateRent(rent);
                    if (result != null)
                    {
                        return RedirectToAction(nameof(Create), "Payment", new { idRent = result });
                    }
                    ViewData["CreatingError"] = "Something went wrong with your rent.";
                }
            }
            ViewData["NotificationMessage"] = "No movie selected.";
            ViewData["MoviesIds"] = new MultiSelectList(rentService.GetAllMovies().Where(m => m.RentId == null), "Id_Movie", "Title");//displays only available movies 
            ViewData["UserId"] = new SelectList(rentService.GetAllUsers(), "Id_User", "Name", "Surname");
            return View("Create");
        }
    }
}
