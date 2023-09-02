using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Tests.Dummies
{
    public class PaymentRepoDummy : IPaymentRepository
    {
        void IPaymentRepository.DeletePayment(int id)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        Payment IPaymentRepository.GetPayment(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Payment> IPaymentRepository.GetPayments()
        {
            throw new NotImplementedException();
        }

        int IPaymentRepository.InsertPayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        void IPaymentRepository.Save()
        {
            throw new NotImplementedException();
        }

        void IPaymentRepository.UpdatePayment(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
