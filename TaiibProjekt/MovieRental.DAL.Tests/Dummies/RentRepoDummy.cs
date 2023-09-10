using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Tests.Dummies
{
    public class RentRepoDummy : IRentRepository
    {
        public void DeleteRent(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Rent GetRent(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rent> GetRents()
        {
            throw new NotImplementedException();
        }

        public int InsertRent(Rent rent)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateRent(Rent rent)
        {
            throw new NotImplementedException();
        }
    }
}
