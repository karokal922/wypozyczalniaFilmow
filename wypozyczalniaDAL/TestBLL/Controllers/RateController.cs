using Microsoft.AspNetCore.Mvc;
using MovieRentalBLL.Interfaces;

namespace TestBLL.Controllers
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
            ViewBag.AverageRatePerMovie=_rateService.GetAverageRatePerMovie();
            return View("Index");
        }

        public IActionResult ShowAverageRatePerUser()
        {
            ViewBag.AverageRatePerUser = _rateService.GetAverageRatePerMovie();
            return View("Index");
        }
    }
}
