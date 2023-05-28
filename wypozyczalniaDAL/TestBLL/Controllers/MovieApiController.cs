using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalBLL.Interfaces;
using wypozyczalniaDAL.Models;

namespace TestBLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieApiController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieApiController(IMovieService movieService)
        {
            this._movieService = movieService;
        }
        [HttpGet("GetMoviesByCategory")]
        public IEnumerable<Movie> GetMoviesByCategory(int category_id)
        {
            return _movieService.GetMoviesByCategory(category_id);
        }
        [HttpGet("SortMoviesByRatingsInGivenYear")]
        public IEnumerable<Movie> SortMoviesByRatingsInGivenYear(int year)
        {
            return _movieService.SortMoviesByRatingsInGivenYear(year);
        }
    }
}
