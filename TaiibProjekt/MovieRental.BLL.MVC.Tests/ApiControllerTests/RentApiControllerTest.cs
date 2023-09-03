using Moq;
using MovieRental.BLL.Interfaces;
using MovieRental.BLL.MVC.Controllers;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.MVC.Tests.ApiControllerTests
{
    public class RentApiControllerTest
    {
        private List<Payment> GetPaymentList_Mock()
        {
            return new List<Payment>
            {
                new Payment
                {
                    Id_Payment = 1,
                    Price = 12,
                    RentId = 1,
                },
                new Payment
                {
                    Id_Payment = 2,
                    Price = 23,
                    RentId = 2,
                },
                new Payment
                {
                    Id_Payment = 3,
                    Price = 34,
                    RentId = 3,
                }
            };
        }
        private List<Rent> getRentList_Mock()
        {
            var paymentList = GetPaymentList_Mock();
            return new List<Rent>
            {
                new Rent { Id_Rent = 1, Movies = new List<Movie>(), Payment = paymentList[0], UserId = 1, RentingDate = DateTime.Now.AddDays(-7) },
                  new Rent { Id_Rent = 2, Movies = new List<Movie>(), Payment = paymentList[1], UserId = 2, RentingDate = DateTime.Now.AddDays(-14) },
                  new Rent { Id_Rent = 3, Movies = new List<Movie>(), Payment = paymentList[2], UserId = 3, RentingDate = DateTime.Now.AddDays(-21) }
            };
        }
        [Fact]
        public void TestGetRentalsByUserAction()
        {
            Mock<IRentService> mockRentService = new Mock<IRentService>();

            var lista = getRentList_Mock();

            mockRentService.Setup(s => s.GetRentalsByUser(1)).Returns(lista);

            RentApiController rentApiController = new RentApiController(mockRentService.Object);

            Assert.Same(lista, rentApiController.GetRentalsByUser(1));
        }
        [Fact]
        public void TestGetRentalsByMovieAction()
        {
            Mock<IRentService> mockRentService = new Mock<IRentService>();

            var lista = getRentList_Mock();

            mockRentService.Setup(s => s.GetRentalsByMovie(1)).Returns(lista);

            RentApiController rentApiController = new RentApiController(mockRentService.Object);
            Assert.Same(lista, rentApiController.GetRentalsByMovie(1));
        }
    }
}
