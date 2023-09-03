using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.BLL.Interfaces;
using MovieRental.DAL.Models;

namespace MovieRental.BLL.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentApiController : ControllerBase
    {
        private readonly IRentService rentService;
        //private IRentService @object;

        public RentApiController(IRentService service)
        {
            this.rentService = service;
        }

        [HttpGet("GetRentalsByUser")]
        public List<Rent> GetRentalsByUser(int userId)
        {
            return rentService.GetRentalsByUser(userId);
        }
        [HttpGet("GetRentalsByMovie")]
        public List<Rent> GetRentalsByMovie(int movieId)
        {
            return rentService.GetRentalsByMovie(movieId);
        }
    }
}
