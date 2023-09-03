using Moq;
using MovieRental.BLL.Interfaces;
using MovieRental.BLL.MVC.Controllers;
using MovieRental.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.MVC.Tests.ApiControllerTests
{
    public class RateApiControllerTest
    {
        [Fact]
        public void TestGetAverageRatePerMovieAction()
        {
            Mock<IRateService> mockRateService = new Mock<IRateService>();

            var lista = new List<MovieRatingResult>
            {
                new MovieRatingResult{  MovieId = 1, MovieTitle = "movie1", AverageRate = 5.12},
                new MovieRatingResult{  MovieId = 2, MovieTitle = "movie2", AverageRate = 3.32},
                new MovieRatingResult{  MovieId = 3, MovieTitle = "movie3", AverageRate = 7.56},
                new MovieRatingResult{  MovieId = 4, MovieTitle = "movie4", AverageRate = 9.52}
            };

            mockRateService.Setup(s => s.GetAverageRatePerMovie()).Returns(lista);

            RateApiController rateApiController = new RateApiController(mockRateService.Object);

            Assert.Same(lista, rateApiController.GetAverageRatePerMovie());
        }
        [Fact]
        public void TestGetAverageRatePerUserAction()
        {
            Mock<IRateService> mockRateService = new Mock<IRateService>();

            var lista = new List<UserRatingResult>
            {
                new UserRatingResult{  UserId = 1, UserName = "user1", AverageRate = 5.12},
                new UserRatingResult{  UserId = 2, UserName = "user2", AverageRate = 3.32},
                new UserRatingResult{  UserId = 3, UserName = "user3", AverageRate = 7.56},
                new UserRatingResult{  UserId = 4, UserName = "user4", AverageRate = 9.52}
            };

            mockRateService.Setup(s => s.GetAverageRatePerUser()).Returns(lista);

            RateApiController rateApiController = new RateApiController(mockRateService.Object);

            Assert.Same(lista, rateApiController.GetAverageRatePerUser());
        }
    }
}
