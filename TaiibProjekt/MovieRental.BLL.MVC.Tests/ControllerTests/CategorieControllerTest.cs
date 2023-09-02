using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieRental.BLL.Interfaces;
using MovieRental.BLL.MVC.Controllers;
using MovieRental.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.MVC.Tests.ControllerTests
{
    public class CategorieControllerTest
    {
        [Fact]
        public void TestGetCategoriesWithMovieCountAction()
        {
            Mock<ICategoryService> mockCategoryService = new Mock<ICategoryService>();

            var categoriesWithMovieCount = new List<CategoryMovieCountResult>
            {
                new CategoryMovieCountResult{ CategoryName = "Action", MovieCount = 5 },
                new CategoryMovieCountResult{ CategoryName = "Comedy", MovieCount = 1 },
                new CategoryMovieCountResult{ CategoryName = "Drama", MovieCount = 3 },
                new CategoryMovieCountResult{ CategoryName = "Thriller", MovieCount = 11 }
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
