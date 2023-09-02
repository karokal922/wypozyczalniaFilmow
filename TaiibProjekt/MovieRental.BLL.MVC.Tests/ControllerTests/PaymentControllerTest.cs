using Microsoft.AspNetCore.Mvc;
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
    public class PaymentControllerTest
    {
        [Fact]
        public void TestGetPaymentsInRangeAction()
        {
            Mock<IPaymentService> mockPaymentService = new Mock<IPaymentService>();
            PaymentController paymentController = new PaymentController(mockPaymentService.Object);

            var payment1 = new Payment { Id_Payment = 1, Price = 10.99 };
            var payment2 = new Payment { Id_Payment = 2, Price = 19.99 };
            var payment3 = new Payment { Id_Payment = 3, Price = 15.0 };
            var payment4 = new Payment { Id_Payment = 4, Price = 8.5 };
            var payment5 = new Payment { Id_Payment = 5, Price = 12.75 };

            var paymentList = new List<Payment> { payment1, payment2, payment3, payment4, payment5 };
            mockPaymentService.Setup(s => s.GetPaymentsInRange(5.0, 20.0)).Returns(paymentList);
            var result = paymentController.ShowPaymentsInRange(5.0, 20.0);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Equal(paymentList, viewResult.ViewData["PaymentsInRange"]);
        }

        [Fact]
        public void TestGetAveragePaymentValueAction()
        {
            Mock<IPaymentService> mockPaymentService = new Mock<IPaymentService>();
            PaymentController paymentController = new PaymentController(mockPaymentService.Object);
            
            var userAvgPayment = new UserAveragePaymentResult { UserName = "Jan", AveragePayment = 12.78 };
            mockPaymentService.Setup(s => s.GetUserAveragePaymentValue(1)).Returns(userAvgPayment);
            var result = paymentController.ShowAveragePaymentValueForUser(1);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Equal(userAvgPayment, viewResult.ViewData["AveragePayment"]);
        }
    }
}
