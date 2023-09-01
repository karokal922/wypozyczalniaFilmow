using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using MovieRental.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public UserAveragePaymentResult GetUserAveragePaymentValue(int userId)
        {
            //var rents = unitOfWork.RentRepository.GetRents().Where(r => r.UserId == userId).ToList();
            //var paymentIds = rents.Select(r => r.Payment.Id_Payment).Distinct();
            //var payments = unitOfWork.PaymentRepository.GetPayments()
            //    .Where(p => paymentIds.Contains(p.Id_Payment)).ToList();
            //return payments.Average(p => p.Price);
            var payments = unitOfWork.PaymentRepository.GetPayments().Where(p => p.Rent.UserId == userId);
            var queryResult = new UserAveragePaymentResult
            {
                UserName = unitOfWork.UserRepository.GetUser(userId).Name,
                AveragePayment = payments.Average(p => p.Price)
            };

            return queryResult;
        }

        public IEnumerable<Payment> GetPaymentsInRange(double minPrice, double maxPrice)
        {
            var payments = unitOfWork.PaymentRepository.GetPayments()
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
            return payments;
        }
    }
    public class UserAveragePaymentResult
    {
        public string UserName { get; set; }
        public double AveragePayment { get; set; }
    }
}
