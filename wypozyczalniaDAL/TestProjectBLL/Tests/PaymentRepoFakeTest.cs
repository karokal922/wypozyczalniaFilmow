using Moq;
using MovieRentalBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;

namespace TestProjectBLL
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

            var result=paymentBLL.GetPaymentsInRange(5.0,13.0);

            Assert.Equal(3, result.Count());

        }

        [Fact]
        public void GetPaymentsInRangeTestMoq()
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
    }
}
