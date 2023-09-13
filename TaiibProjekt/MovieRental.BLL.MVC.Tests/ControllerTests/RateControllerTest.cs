using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using MovieRental.BLL.Interfaces;
using MovieRental.BLL.MVC.Controllers;
using MovieRental.BLL.Services;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.MVC.Tests.ControllerTests
{
    public class RateControllerTest
    {
        [Fact]
        public void TestGetAverageRatePerMovieAction()
        {
            Mock<IRateService> mockRateService = new Mock<IRateService>();
            RateController ratesController = new RateController(mockRateService.Object);

            var lista = new List<MovieRatingResult>
            {
                new MovieRatingResult{  MovieId = 1, MovieTitle = "movie1", AverageRate = 5.12},
                new MovieRatingResult{  MovieId = 2, MovieTitle = "movie2", AverageRate = 3.32},
                new MovieRatingResult{  MovieId = 3, MovieTitle = "movie3", AverageRate = 7.56},
                new MovieRatingResult{  MovieId = 4, MovieTitle = "movie4", AverageRate = 9.52}
            };
            mockRateService.Setup(s => s.GetAverageRatePerMovie()).Returns(lista);
            var result = ratesController.ShowAverageRatePerMovie();

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Same(lista, viewResult.ViewData["AverageRatePerMovie"]);
        }
        [Fact]
        public void TestGetAverageRatePerUserAction()
        {
            Mock<IRateService> mockRateService = new Mock<IRateService>();
            RateController ratesController = new RateController(mockRateService.Object);

            var lista = new List<UserRatingResult>
            {
                new UserRatingResult{  UserId = 1, UserName = "user1", AverageRate = 5.12},
                new UserRatingResult{  UserId = 2, UserName = "user2", AverageRate = 3.32},
                new UserRatingResult{  UserId = 3, UserName = "user3", AverageRate = 7.56},
                new UserRatingResult{  UserId = 4, UserName = "user4", AverageRate = 9.52}
            };
            mockRateService.Setup(s => s.GetAverageRatePerUser()).Returns(lista);
            var result = ratesController.ShowAverageRatePerUser();

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Same(lista, viewResult.ViewData["AverageRatePerUser"]);
        }

        [Fact]
        public void Index_ReturnsViewResult()
        {
            var rateServiceMock = new Mock<IRateService>();
            var controller = new RateController(rateServiceMock.Object);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_GET_ReturnsViewResultWithSelectLists()
        {
            var rateServiceMock = new Mock<IRateService>();
            rateServiceMock.Setup(r => r.GetAllMovies()).Returns(new List<Movie>());
            rateServiceMock.Setup(r => r.GetAllUsers()).Returns(new List<User>());
            var controller = new RateController(rateServiceMock.Object);

            var result = controller.Create() as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<SelectList>(result.ViewData["MovieId"]);
            Assert.IsType<SelectList>(result.ViewData["UserId"]);
        }

        [Fact]
        public void Create_POST_InvalidModel_ReturnsViewResultWithModelError()
        {
            var rateServiceMock = new Mock<IRateService>();
            var controller = new RateController(rateServiceMock.Object);
            controller.ModelState.AddModelError("UserId", "UserId is required");
            var rate = new Rate { UserId = 1, MovieId = 2 };

            var result = controller.Create(rate) as ViewResult;

            Assert.NotNull(result);
            Assert.True(result.ViewData.ModelState.ContainsKey("UserId"));
        }

        [Fact]
        public void Create_POST_ExistingRate_ReturnsViewResultWithCreatingError()
        {
            var rateServiceMock = new Mock<IRateService>();
            rateServiceMock.Setup(r => r.GetAllRates()).Returns(new List<Rate> { new Rate { UserId = 1, MovieId = 2 } });
            var controller = new RateController(rateServiceMock.Object);
            var rate = new Rate { UserId = 1, MovieId = 2 };

            var result = controller.Create(rate) as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Rate from that user to this movie already exists.", result.ViewData["CreatingError"]);
        }
    }
}
