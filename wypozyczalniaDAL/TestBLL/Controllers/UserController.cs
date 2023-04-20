using Microsoft.AspNetCore.Mvc;
using MovieRentalBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MovieRentalBLL.Interfaces;
using MovieRentalBLL.Services;
using System.Linq.Expressions;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;

namespace TestBLL.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult ShowUsers(string username)
        {
            var users = _userService.GetUsersByNameSorted(username);
            
            ViewBag.Users = users;
            return View("Index");
        }
        public IActionResult ShowUsersWithRateCount() {
            var users = _userService.GetUsersWithRateCountSorted();
            ViewBag.UsersWithRateCount = users;
            return View("Index");
        }
    }
}
