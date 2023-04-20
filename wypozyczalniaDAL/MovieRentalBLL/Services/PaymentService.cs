using Microsoft.EntityFrameworkCore;
using MovieRentalBLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;

namespace MovieRentalBLL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public double GetAveragePaymentValue(int userId, DateTime startDate, DateTime endDate)
        {
            var rents = unitOfWork.RentRepository.GetRents()
        .Where(r => r.User_ID == userId && r.RentingDate >= startDate && r.RentingDate <= endDate)
        .ToList();
            var paymentIds = rents.Select(r => r.Payment_ID).Distinct();
            var payments = unitOfWork.PaymentRepository.GetPayments()
                .Where(p => paymentIds.Contains(p.Id_Payment))
                .ToList();
            return payments.Average(p => p.Price);
        }

        public IEnumerable<Payment> GetPaymentsInRange(double minPrice, double maxPrice)
        {
            var payments = unitOfWork.PaymentRepository.GetPayments()
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToList();
            return payments;
        }


    }
}
