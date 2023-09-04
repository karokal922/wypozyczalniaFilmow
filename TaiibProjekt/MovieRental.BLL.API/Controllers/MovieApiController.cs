using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.BLL.Interfaces;
using MovieRental.DAL.Models;

namespace MovieRental.BLL.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieApiController : ControllerBase
    {
        private readonly IMovieService movieService;
        public MovieApiController(IMovieService movieService)
        {
            this.movieService = movieService;
        }
        [HttpGet("GetMoviesByCategory")]
        public IEnumerable<Movie> GetMoviesByCategory(int category_id)
        {
            return movieService.GetMoviesByCategory(category_id);
        }
        [HttpGet("SortMoviesByAvgRatingsInGivenYear")]
        public IEnumerable<Movie> SortMoviesByAvgRatingsInGivenYear(int year)
        {
            return movieService.SortMoviesByAvgRatingsInGivenYear(year);
        }
    }
}
