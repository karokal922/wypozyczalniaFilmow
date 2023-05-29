using MovieRentalBLL;
using wypozyczalniaDAL;
using Moq;
using MovieRentalBLL.Interfaces;
using wypozyczalniaDAL.Models;
using TestBLL;
using TestBLL.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestControllersMVC.ControllerTests
{
    public class UnitTestCategoriesController
    {
        [Fact]
        public void TestGetCategoriesWithMovieCountAction()
        {
            Mock<ICategoryService> mockCategoryService = new Mock<ICategoryService>();

            var categoriesWithMovieCount = new List<object>
            {
                new { CategoryName = "Action", MovieCount = 5 },
                new { CategoryName = "Comedy", MovieCount = 1 },
                new { CategoryName = "Drama", MovieCount = 3 },
                new { CategoryName = "Thriller", MovieCount = 11 }
            };
            mockCategoryService
               .Setup(s => s.GetCategoriesWithMovieCount())
               .Returns(categoriesWithMovieCount);        

            CategoryController categoryController = new CategoryController(mockCategoryService.Object);

            var result = categoryController.ShowCategoriesWithMovieCount();

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Same(categoriesWithMovieCount, viewResult.ViewData["CategoriesWithMovieCount"]);
        }
    }
}