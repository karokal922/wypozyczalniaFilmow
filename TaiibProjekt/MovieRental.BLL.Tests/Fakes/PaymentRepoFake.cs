using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Tests.Fakes
{
    public class PaymentRepoFake : IPaymentRepository
    {
        private readonly List<Payment> _payments = new List<Payment>();
        public IReadOnlyList<Payment> AllPayments => _payments.AsReadOnly();
        public void DeletePayment(int id)
        {
            foreach (Payment payment in _payments)
            {
                if (payment.Id_Payment == id)
                {
                    _payments.Remove(payment);
                }
            }
        }

        public void Dispose()
        {
            _payments.Clear();
        }

        public Payment GetPayment(int id)
        {
            return _payments
                .Where(m => m.Id_Payment == id)
                .FirstOrDefault();
        }

        public IEnumerable<Payment> GetPayments()
        {
            return AllPayments;
        }

        public int InsertPayment(Payment payment)
        {
            _payments.Add(payment);
            return payment.Id_Payment;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdatePayment(Payment payment)
        {
            int index = 0;
            foreach (Payment m in _payments)
            {
                if (m.Id_Payment == payment.Id_Payment)
                {
                    break;
                }
                index++;
            }
            _payments[index] = payment;
        }
    }
}
