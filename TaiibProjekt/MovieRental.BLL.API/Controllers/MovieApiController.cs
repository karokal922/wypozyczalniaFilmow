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
        [HttpGet("GetMoviesByCategory/{id}")]
        public IEnumerable<Movie> GetMoviesByCategory(int id)
        {
            return movieService.GetMoviesByCategory(id);
        }
        [HttpGet("SortMoviesByAvgRatingsInGivenYear/{year}")]
        public IEnumerable<Movie> SortMoviesByAvgRatingsInGivenYear(int year)
        {
            return movieService.SortMoviesByAvgRatingsInGivenYear(year);
        }
    }
}
