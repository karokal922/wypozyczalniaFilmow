﻿using Microsoft.AspNetCore.Mvc;
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
    public class UnitTestPaymentsController
    {
        [Fact]
        public void TestGetPaymentsInRangeAction()
        {
            Mock<IPaymentService> mockPaymentService = new Mock<IPaymentService>();

            var payment1 = new Payment { Id_Payment = 1, Price = 10.99 };
            var payment2 = new Payment { Id_Payment = 2, Price = 19.99 };
            var payment3 = new Payment { Id_Payment = 3, Price = 15.0 };
            var payment4 = new Payment { Id_Payment = 4, Price = 8.5 };
            var payment5 = new Payment { Id_Payment = 5, Price = 12.75 };

            var paymentList = new List<Payment> { payment1, payment2, payment3, payment4, payment5 };

            mockPaymentService
               .Setup(s => s.GetPaymentsInRange(5.0,20.0))
               .Returns(paymentList);

            PaymentController paymentController = new PaymentController(mockPaymentService.Object);

            var result = paymentController.ShowPaymentsInRange(5.0,20.0);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Equal(paymentList, viewResult.ViewData["PaymentsInRange"]);
        }

        [Fact]
        public void TestGetAveragePaymentValueAction()
        {
            Mock<IPaymentService> mockPaymentService = new Mock<IPaymentService>();

            mockPaymentService
               .Setup(s => s.GetAveragePaymentValue(1, new DateTime(2023, 1, 1), new DateTime(2023, 12, 31)))
               .Returns(12.78);

            PaymentController paymentController = new PaymentController(mockPaymentService.Object);

            var result = paymentController.ShowAveragePaymentValueForUser(1, new DateTime(2023, 1, 1), new DateTime(2023, 12, 31));

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Equal(12.78, viewResult.ViewData["AveragePayment"]);
        }
    }
}
