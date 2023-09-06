using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieRental.BLL.Interfaces;
using MovieRental.DAL.Models;
using MovieRental.DAL.Repositories;

namespace MovieRental.BLL.MVC.Controllers
{
    public class RateController : Controller
    {
        private readonly IRateService rateService;

        public RateController(IRateService rateService)
        {
            this.rateService = rateService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowAverageRatePerMovie()
        {
            ViewBag.AverageRatePerMovie = rateService.GetAverageRatePerMovie();
            return View("Index");
        }

        public IActionResult ShowAverageRatePerUser()
        {
            ViewBag.AverageRatePerUser = rateService.GetAverageRatePerUser();
            return View("Index");
        }
 
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(rateService.GetAllMovies(), "Id_Movie", "Title");
            ViewData["UserId"] = new SelectList(rateService.GetAllUsers(), "Id_User", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Rate rate)
        {
            ModelState.Remove("User");
            ModelState.Remove("Movie");
            if (ModelState.IsValid)
            {
                var isExistingRate = rateService.GetAllRates().Where(r => r.UserId == rate.UserId && r.MovieId == rate.MovieId);
                if (isExistingRate.Count() == 0) 
                {
                    var user = rateService.GetAllUsers().Where(r => r.Id_User == rate.UserId).FirstOrDefault();
                    var movie = rateService.GetAllMovies().Where(m => m.Id_Movie == rate.MovieId).FirstOrDefault();
                    if(user!= null && movie != null)
                    {
                        rate.User = user;
                        rate.Movie = movie;
                        rateService.CreateRate(rate);
                        return RedirectToAction(nameof(Index));
                    }
                }
                ViewData["CreatingError"] = "Rate from that user to this movie already exists.";
            }
            ViewData["MovieId"] = new SelectList(rateService.GetAllMovies(), "Id_Movie", "Title", rate.MovieId);
            ViewData["UserId"] = new SelectList(rateService.GetAllUsers(), "Id_User", "Name", rate.UserId);
            return View(rate);
        }
    }
}
