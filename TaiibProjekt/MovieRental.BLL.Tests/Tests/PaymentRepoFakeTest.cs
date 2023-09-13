using Moq;
using MovieRental.BLL.Services;
using MovieRental.BLL.Tests.Fakes;
using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using MovieRental.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Tests.Tests
{
    public class PaymentRepoFakeTest
    {
        [Fact]
        public void GetPaymentsInRangeTest()
        {
            var paymentRepo = new PaymentRepoFake();
            var unityOfWork = new UnitOfWork(paymentRepo);
            var paymentBLL = new PaymentService(unityOfWork);

            paymentRepo.InsertPayment(new Payment { Id_Payment = 1, Price = 10.5 });
            paymentRepo.InsertPayment(new Payment { Id_Payment = 2, Price = 12.79 });
            paymentRepo.InsertPayment(new Payment { Id_Payment = 3, Price = 5.41 });
            paymentRepo.InsertPayment(new Payment { Id_Payment = 4, Price = 18.5 });
            paymentRepo.InsertPayment(new Payment { Id_Payment = 5, Price = 2.5 });

            var result = paymentBLL.GetPaymentsInRange(5.0, 13.0);

            Assert.Equal(3, result.Count());

        }

        [Fact]
        public void GetPaymentsInRangeTestMoq_PaymentInRange()
        {
            Mock<IPaymentRepository> mockPaymentRepo = new Mock<IPaymentRepository>();
            mockPaymentRepo.Setup(x => x.GetPayments())
                .Returns(new List<Payment> { new Payment { Id_Payment = 1, Price = 10.5 }, new Payment { Id_Payment = 2, Price = 12.79 },
                                             new Payment { Id_Payment = 3, Price = 5.41 }, new Payment { Id_Payment = 4, Price = 18.5 },
                                             new Payment { Id_Payment = 5, Price = 2.5 }
                });

            var unityOfWork = new UnitOfWork(mockPaymentRepo.Object);
            var paymentBLL = new PaymentService(unityOfWork);

            var result = paymentBLL.GetPaymentsInRange(5.0, 13.0);

            Assert.Equal(3, result.Count());

        }
        [Fact]
        public void GetPaymentsInRangeTestMoq_PaymentOutOfRange()
        {
            Mock<IPaymentRepository> mockPaymentRepo = new Mock<IPaymentRepository>();
            mockPaymentRepo.Setup(x => x.GetPayments())
                .Returns(new List<Payment> { new Payment { Id_Payment = 1, Price = 10.5 }, new Payment { Id_Payment = 2, Price = 12.79 },
                                             new Payment { Id_Payment = 3, Price = 5.41 }, new Payment { Id_Payment = 4, Price = 18.5 },
                                             new Payment { Id_Payment = 5, Price = 2.5 }
                });

            var unityOfWork = new UnitOfWork(mockPaymentRepo.Object);
            var paymentBLL = new PaymentService(unityOfWork);

            var result = paymentBLL.GetPaymentsInRange(0.0, 1.0);

            Assert.Equal(0, result.Count());

        }
        [Fact]
        public void GetPaymentsInRangeTestMoq_InvalidPaymentShouldReturnNull()
        {
            Mock<IPaymentRepository> mockPaymentRepo = new Mock<IPaymentRepository>();
            mockPaymentRepo.Setup(x => x.GetPayments());

            var unityOfWork = new UnitOfWork(mockPaymentRepo.Object);
            var paymentBLL = new PaymentService(unityOfWork);

            var result = paymentBLL.GetPaymentsInRange(0.0, 5.0);

            Assert.Empty(result);

        }


        [Fact]
        public void GetUserAveragePaymentValue_UserWithNoPaymentsShouldReturnNull()
        {
            var userId = 1;

            var paymentRepoMock = new Mock<IPaymentRepository>();
            paymentRepoMock.Setup(repo => repo.GetPayments()).Returns(new List<Payment>());

            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(repo => repo.GetUser(userId)).Returns(new User { Id_User = userId, Name = "John", Surname = "Doe" });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.SetupGet(uow => uow.PaymentRepository).Returns(paymentRepoMock.Object);
            unitOfWorkMock.SetupGet(uow => uow.UserRepository).Returns(userRepoMock.Object);

            var paymentService = new PaymentService(unitOfWorkMock.Object);

            var result = paymentService.GetUserAveragePaymentValue(userId);

            Assert.Null(result);
        }

        [Fact]
        public void GetUserAveragePaymentValue_ValidUserIdShouldReturnsAveragePayment()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var userId = 1;
            var payments = new List<Payment>
                {
                    new Payment { Id_Payment = 1, Price = 10.0, Rent = new Rent { UserId = 1 } },
                    new Payment { Id_Payment = 2, Price = 20.0, Rent = new Rent { UserId = 1 } },
                };

            mockUnitOfWork.Setup(uow => uow.PaymentRepository.GetPayments()).Returns(payments);
            mockUnitOfWork.Setup(uow => uow.UserRepository.GetUser(userId)).Returns(new User { Id_User = userId, Name = "User1"});

            var paymentService = new PaymentService(mockUnitOfWork.Object);

            var result = paymentService.GetUserAveragePaymentValue(userId);

            Assert.NotNull(result);
            Assert.Equal("User1", result.UserName);
            Assert.Equal(15.0, result.AveragePayment, 2);
        }

        [Fact]
        public void GetUserAveragePaymentValue_InvalidUserIdShouldReturnNull()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var userId = 1;
            var payments = new List<Payment>();

            mockUnitOfWork.Setup(uow => uow.PaymentRepository.GetPayments()).Returns(payments);
            mockUnitOfWork.Setup(uow => uow.UserRepository.GetUser(userId)).Returns((User)null);

            var paymentService = new PaymentService(mockUnitOfWork.Object);

            var result = paymentService.GetUserAveragePaymentValue(userId);

            Assert.Null(result);
        }

        [Fact]
        public void CreatePayment_ValidPaymentShouldReturnPaymentId()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var payment = new Payment { Id_Payment = 1, Price = 10.0, Rent = new Rent { UserId = 1 } };

            mockUnitOfWork.Setup(uow => uow.PaymentRepository.InsertPayment(payment)).Callback(() => payment.Id_Payment = 1);
            var paymentService = new PaymentService(mockUnitOfWork.Object);

            var result = paymentService.CreatePayment(payment);

            Assert.NotNull(result);
            Assert.Equal(1, result);
        }

        [Fact]
        public void CreatePayment_InvalidPaymentShouldReturnNull()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var payment = new Payment { Id_Payment = 1, Price = -10.0 };

            var paymentService = new PaymentService(mockUnitOfWork.Object);

            var result = paymentService.CreatePayment(payment);

            Assert.Null(result);
        }
    }
}
