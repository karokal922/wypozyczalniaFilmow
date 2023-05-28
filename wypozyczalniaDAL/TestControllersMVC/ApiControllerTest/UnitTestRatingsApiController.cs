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
    public class UnitTestRatingsApiController
    {
        [Fact]
        public void TestGetAverageRatePerMovieAction()
        {
            Mock<IRateService> mockRateService = new Mock<IRateService>();

            var lista = new List<object>
            {
                new {  MovieId = 1, AverageRate = 5.12},
                new {  MovieId = 2, AverageRate = 3.32},
                new {  MovieId = 3, AverageRate = 7.56},
                new {  MovieId = 4, AverageRate = 9.52}
            };

            mockRateService
               .Setup(s => s.GetAverageRatePerMovie())
               .Returns(lista);

            RateApiController rateApiController = new RateApiController(mockRateService.Object);

            Assert.Same(lista, rateApiController.GetAverageRatePerMovie());
        }
        [Fact]
        public void TestGetAverageRatePerUserAction()
        {
            Mock<IRateService> mockRateService = new Mock<IRateService>();

            var lista = new List<object>
            {
                new {  UserId = 1, AverageRate = 5.12},
                new {  UserId = 2, AverageRate = 3.32},
                new {  UserId = 3, AverageRate = 7.56},
                new {  UserId = 4, AverageRate = 9.52}
            };

            mockRateService
               .Setup(s => s.GetAverageRatePerUser())
               .Returns(lista);

            RateApiController rateApiController = new RateApiController(mockRateService.Object);

            Assert.Same(lista, rateApiController.GetAverageRatePerUser());
        }
    }
}
