using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieRental.BLL.Interfaces;
using MovieRental.DAL.Repositories;

namespace MovieRental.BLL.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowCategoriesWithMovieCount()
        {
            ViewBag.CategoriesWithMovieCount = categoryService.GetCategoriesWithMovieCount();
            return View("Index");
        }
    }
}
