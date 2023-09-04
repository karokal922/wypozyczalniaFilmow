using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.BLL.Interfaces;
using MovieRental.BLL.Services;

namespace MovieRental.BLL.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateApiController : ControllerBase
    {
        private readonly IRateService rateService;
        public RateApiController(IRateService rateService)
        {
            this.rateService = rateService;
        }
        [HttpGet("GetAverageRatePerMovie")]
        public IEnumerable<MovieRatingResult> GetAverageRatePerMovie()
        {
            return rateService.GetAverageRatePerMovie();
        }
        [HttpGet("GetAverageRatePerUser")]
        public IEnumerable<UserRatingResult> GetAverageRatePerUser()
        {
            return rateService.GetAverageRatePerUser();
        }
    }
}
