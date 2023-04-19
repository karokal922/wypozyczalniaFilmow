using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Models;

namespace wypozyczalniaDAL.Interfaces
{
    public interface IPaymentRepository : IDisposable
    {
        IEnumerable<Payment> GetPayments();
        Payment GetPayment(int id);
        void InsertPayment(Payment payment);
        void DeletePayment(int id);
        void UpdatePayment(Payment payment);
        void Save();
    }
}
