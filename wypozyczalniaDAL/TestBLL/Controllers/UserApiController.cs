using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalBLL.Interfaces;
using wypozyczalniaDAL.Models;

namespace TestBLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetUsersByNameSorted")]
        public IEnumerable<User> GetUsersByNameSorted(string name)
        {
            return _userService.GetUsersByNameSorted(name);
        }
        [HttpGet("GetUsersWithRateCountSorted")]
        public IEnumerable<object> GetUsersWithRateCountSorted()
        {
            return _userService.GetUsersWithRateCountSorted();
        }
    }
}
