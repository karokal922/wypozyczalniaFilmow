using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieRentalBLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBLL.Controllers;
using wypozyczalniaDAL.Models;

namespace TestControllersMVC.ControllerTests
{
    public class UnitTestRentalsController
    {
        [Fact]
        public void TestGetRentalsByUserAction()
        {
            Mock<IRentService> mockRentService = new Mock<IRentService>();

            var lista = new List<Rent>
            {
                  new Rent {Id_Rate = 1,Movies = new List<Movie>(), Payment_ID = 1, User_ID = 1,RentingDate = DateTime.Now.AddDays(-7) },
                  new Rent {Id_Rate = 2,Movies = new List<Movie>(),Payment_ID = 2,User_ID = 2,RentingDate = DateTime.Now.AddDays(-14)},
                  new Rent{Id_Rate = 3, Movies = new List<Movie>(), Payment_ID = 3,User_ID = 3,RentingDate = DateTime.Now.AddDays(-21) }
            };

            mockRentService
               .Setup(s => s.GetRentalsByUser(1))
               .Returns(lista);

            RentController rentController = new RentController(mockRentService.Object);


            var result = rentController.GetRentalsByUser(1);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Equal(lista, viewResult.ViewData["RentalsByUser"]);
        }
        [Fact]
        public void TestGetRentalsByMovieAction()
        {
            Mock<IRentService> mockRentService = new Mock<IRentService>();

            var lista = new List<Rent>
            {
                  new Rent {Id_Rate = 1,Movies = new List<Movie>(), Payment_ID = 1, User_ID = 1,RentingDate = DateTime.Now.AddDays(-7) },
                  new Rent {Id_Rate = 2,Movies = new List<Movie>(),Payment_ID = 2,User_ID = 2,RentingDate = DateTime.Now.AddDays(-14)},
                  new Rent{Id_Rate = 3, Movies = new List<Movie>(), Payment_ID = 3,User_ID = 3,RentingDate = DateTime.Now.AddDays(-21) }
            };

            mockRentService
               .Setup(s => s.GetRentalsByMovie(1))
               .Returns(lista);

            RentController rentController = new RentController(mockRentService.Object);


            var result = rentController.GetRentalsByMovie(1);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Equal(lista, viewResult.ViewData["RentalsByMovie"]);
        }
    }
}
