using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.BLL.Interfaces;
using MovieRental.BLL.Services;
using MovieRental.DAL.Models;

namespace MovieRental.BLL.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService userService;

        public UserApiController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet("GetUsersByNameSorted")]
        public IEnumerable<User> GetUsersByNameSorted(string name)
        {
            return userService.GetUsersByNameSorted(name);
        }
        [HttpGet("GetUsersWithRateCountSorted")]
        public IEnumerable<UserRateViewModel> GetUsersWithRateCountSorted()
        {
            return userService.GetUsersWithRateCountSorted();
        }
    }
}
