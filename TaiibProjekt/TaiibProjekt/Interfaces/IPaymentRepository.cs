using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Interfaces
{
    public interface IPaymentRepository : IDisposable
    {
        IEnumerable<Payment> GetPayments();
        Payment GetPayment(int id);
        int InsertPayment(Payment payment);
        void DeletePayment(int id);
        void UpdatePayment(Payment payment);
        void Save();
    }
}
