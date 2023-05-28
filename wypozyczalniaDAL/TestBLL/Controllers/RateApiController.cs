using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalBLL.Interfaces;

namespace TestBLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateApiController : ControllerBase
    {
        private readonly IRateService _rateService;
        public RateApiController(IRateService rateService)
        {
            this._rateService = rateService;
        }
        [HttpGet("GetAverageRatePerMovie")]
        public IEnumerable<object> GetAverageRatePerMovie()
        {
            return _rateService.GetAverageRatePerMovie();
        }
        [HttpGet("GetAverageRatePerUser")]
        public IEnumerable<object> GetAverageRatePerUser()
        {
            return _rateService.GetAverageRatePerUser();
        }
    }
}
