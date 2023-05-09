using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;

namespace TestProjectDAL
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

        public void InsertRent(Rent rent)
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
