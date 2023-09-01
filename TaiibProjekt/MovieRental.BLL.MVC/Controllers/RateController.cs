using Microsoft.AspNetCore.Mvc;
using MovieRental.BLL.Interfaces;

namespace MovieRental.BLL.MVC.Controllers
{
    public class RateController : Controller
    {
        private readonly IRateService _rateService;

        public RateController(IRateService rateService)
        {
            this._rateService = rateService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowAverageRatePerMovie()
        {
            ViewBag.AverageRatePerMovie = _rateService.GetAverageRatePerMovie();
            return View("Index");
        }

        public IActionResult ShowAverageRatePerUser()
        {
            ViewBag.AverageRatePerUser = _rateService.GetAverageRatePerUser();
            return View("Index");
        }
    }
}
