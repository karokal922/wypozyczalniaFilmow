using Microsoft.AspNetCore.Mvc;
using MovieRentalBLL.Interfaces;
using MovieRentalBLL.Services;

namespace TestBLL.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowCategoriesWithMovieCount()
        {
            ViewBag.CategoriesWithMovieCount = _categoryService.GetCategoriesWithMovieCount();
            return View("Index");
        }
    }
}
