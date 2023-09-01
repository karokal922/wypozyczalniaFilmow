using Microsoft.AspNetCore.Mvc;
using MovieRental.BLL.Interfaces;

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
    }
}
