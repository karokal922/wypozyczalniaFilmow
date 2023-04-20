using Microsoft.AspNetCore.Mvc;
using MovieRentalBLL.Interfaces;

namespace TestBLL.Controllers
{
    public class RentController : Controller
    {
        private readonly IRentService _rentService;

        public RentController(IRentService rentService)
        {
            this._rentService = rentService;
        }
        public IActionResult Index()
        {
            ViewBag.AllUsers=_rentService.GetAllUsers();
            ViewBag.AllMovies=_rentService.GetAllMovies();
            return View();
        }

        public IActionResult GetRentalsByMovie(int id)
        {
            ViewBag.RentalByMovie = _rentService.GetRentalsByMovie(id);
            return View("RentalsByMovie");
        }
        public IActionResult GetRentalsByUser(int id)
        {
            ViewBag.RentalByUser = _rentService.GetRentalsByUser(id);
            return View("RentalsByMovie");
        }
    }
}
