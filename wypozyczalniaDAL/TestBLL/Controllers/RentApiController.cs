using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalBLL.Interfaces;
using wypozyczalniaDAL.Models;

namespace TestBLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentApiController : ControllerBase
    {
        private readonly IRentService _service;
        private IRentService @object;

        public RentApiController(IRentService service)
        {
            this._service = service;
        }

        [HttpGet("GetRentalsByUser")]
        public List<Rent> GetRentalsByUser(int userId)
        {
            return _service.GetRentalsByUser(userId);
        }
        [HttpGet("GetRentalsByMovie")]
        public List<Rent> GetRentalsByMovie(int movieId)
        {
            return _service.GetRentalsByMovie(movieId);
        }
    }
}
