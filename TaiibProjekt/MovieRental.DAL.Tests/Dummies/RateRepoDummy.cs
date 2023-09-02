using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Tests.Dummies
{
    internal class RateRepoDummy : IRateRepository
    {
        void IRateRepository.DeleteRate(int id)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        Rate IRateRepository.GetRate(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Rate> IRateRepository.GetRates()
        {
            throw new NotImplementedException();
        }

        void IRateRepository.InsertRate(Rate rate)
        {
            throw new NotImplementedException();
        }

        void IRateRepository.Save()
        {
            throw new NotImplementedException();
        }

        void IRateRepository.UpdateRate(Rate rate)
        {
            throw new NotImplementedException();
        }
    }
}
