using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;

namespace wypozyczalniaDAL.Repositories
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
            return context.Payments.ToList();
        }

        public Payment GetPayment(int id)
        {
            return context.Payments.Find(id);
        }

        public void InsertPayment(Payment sayment)
        {
            context.Payments.Add(sayment);
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
