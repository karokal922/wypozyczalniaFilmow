using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieRentalBLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBLL.Controllers;

namespace TestControllersMVC.ApiControllerTest
{
    public class UnitTestCategoriesApiController
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

            CategoryApiController categoryApiController = new CategoryApiController(mockCategoryService.Object);

            Assert.Same(categoriesWithMovieCount, categoryApiController.GetCategoriesWithMovieCount());
        }
    }
}
