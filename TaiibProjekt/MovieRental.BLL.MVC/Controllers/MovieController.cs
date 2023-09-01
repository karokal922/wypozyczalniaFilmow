using Microsoft.AspNetCore.Mvc;
using MovieRental.BLL.Interfaces;

namespace MovieRental.BLL.MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieSerive)
        {
            this.movieService = movieSerive;
        }

        public IActionResult Index()
        {
            ViewBag.AllCategories = movieService.GetAllCategories();
            return View();
        }

        public IActionResult ShowMovies(int year)
        {
            ViewBag.AllCategories = movieService.GetAllCategories();
            ViewBag.Movies = movieService.SortMoviesByAvgRatingsInGivenYear(year);
            return View("Index");
        }

        public IActionResult GetAllMoviesWithGivenCategory(int id)
        {
            ViewBag.MoviesFromCategory = movieService.GetMoviesByCategory(id);
            return View("AllMoviesFromCategory");
        }
    }
}
