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

namespace TestControllersMVC.ApiControllerTest
{
    public class UnitTestRentalsApiController
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

            RentApiController rentApiController = new RentApiController(mockRentService.Object);

            Assert.Same(lista, rentApiController.GetRentalsByUser(1));
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

            RentApiController rentApiController = new RentApiController(mockRentService.Object);
            Assert.Same(lista, rentApiController.GetRentalsByMovie(1));
        }
    }
}
