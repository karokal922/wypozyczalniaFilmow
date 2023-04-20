using Microsoft.AspNetCore.Mvc;
using MovieRentalBLL.Interfaces;
using MovieRentalBLL.Services;
using System.Linq.Expressions;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;

namespace TestBLL.Controllers
{
    public class MovieController : Controller
    {
       
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieSerive)
        {
            this._movieService = movieSerive;
        }


        // GET: Movies
        public IActionResult Index()
        {
            ViewBag.AllCategories=_movieService.GetAllCategories();
            return View();
        }

        public IActionResult ShowMovies(int year)
        {
            var movies = _movieService.SortMoviesByRatingsInGivenYear(year);
            ViewBag.AllCategories = _movieService.GetAllCategories();
            ViewBag.Movies = movies;
            return View("Index");
        }

        public IActionResult GetAllFilsWithGivenCategory(int id)
        {
            ViewBag.MoviesFromCategory = _movieService.GetMoviesByCategory(id);
            
            return View("AllMoviesFromCategory");
            
        }
    }
}
