using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;

namespace TestProjectBLL
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

        public void InsertPayment(Payment payment)
        {
            _payments.Add(payment);
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
