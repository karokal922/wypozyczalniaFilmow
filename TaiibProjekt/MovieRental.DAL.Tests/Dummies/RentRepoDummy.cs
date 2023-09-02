using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Tests.Dummies
{
    internal class RentRepoDummy : IRentRepository
    {
        void IRentRepository.DeleteRent(int id)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        Rent IRentRepository.GetRent(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Rent> IRentRepository.GetRents()
        {
            throw new NotImplementedException();
        }

        void IRentRepository.InsertRent(Rent rent)
        {
            throw new NotImplementedException();
        }

        void IRentRepository.Save()
        {
            throw new NotImplementedException();
        }

        void IRentRepository.UpdateRent(Rent rent)
        {
            throw new NotImplementedException();
        }
    }
}
