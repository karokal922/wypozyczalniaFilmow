using Microsoft.EntityFrameworkCore;
using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Repositories
{
    public class PaymentRepository : IPaymentRepository, IDisposable
    {
        private MovieRentalContext context;

        public PaymentRepository(MovieRentalContext context)
        {
            this.context = context;
        }

        public IEnumerable<Payment> GetPayments()
        {
            return context.Payments
                .Include(r => r.Rent)
                .ToList();
        }

        public Payment GetPayment(int id)
        {
            return context.Payments
                .Where(p => p.Id_Payment == id)
                .Include(r => r.Rent)
                .FirstOrDefault();
        }

        public int InsertPayment(Payment payment)
        {
            context.Payments.Add(payment);
            context.SaveChanges();
            return payment.Id_Payment;
        }

        public void DeletePayment(int paymentID)
        {
            Payment payment = context.Payments.Find(paymentID);
            context.Payments.Remove(payment);
        }

        public void UpdatePayment(Payment payment)
        {
            context.Entry(payment).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
