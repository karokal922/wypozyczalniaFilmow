using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalBLL.Interfaces;

namespace TestBLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryApiController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet("GetMovieTitlesByCategories")]
        public Dictionary<string, List<string>> GetMovieTitlesByCategories(params string[] categories)
        {
            return _categoryService.GetMovieTitlesByCategories(categories);
        }

        [HttpGet("GetCategoriesWithMovieCount")]
        public IEnumerable<object> GetCategoriesWithMovieCount()
        {
            return _categoryService.GetCategoriesWithMovieCount();
        }
    }
}
