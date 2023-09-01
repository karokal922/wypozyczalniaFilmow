using Microsoft.AspNetCore.Mvc;
using MovieRental.BLL.Interfaces;
using MovieRental.BLL.Services;
using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using MovieRental.DAL.Repositories;

namespace MovieRental.BLL.MVC.Controllers
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
        public IActionResult ShowUsersWithRateCount()
        {
            var users = _userService.GetUsersWithRateCountSorted();
            ViewBag.UsersWithRateCount = users;
            return View("Index");
        }
    }
}
