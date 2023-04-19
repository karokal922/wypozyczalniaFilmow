using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;

namespace MovieRentalBLL.Services
{
    internal class PaymentService
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


    }
}
