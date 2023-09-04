using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.BLL.Interfaces;
using MovieRental.BLL.Services;

namespace MovieRental.BLL.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryApiController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("GetCategoriesWithMovieCount")]
        public IEnumerable<CategoryMovieCountResult> GetCategoriesWithMovieCount()
        {
            return categoryService.GetCategoriesWithMovieCount();
        }
    }
}
