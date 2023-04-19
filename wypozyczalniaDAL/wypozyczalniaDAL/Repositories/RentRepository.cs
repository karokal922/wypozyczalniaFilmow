using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;

namespace wypozyczalniaDAL.Repositories
{
    public class RentRepository : IRenRepository, IDisposable
    {
        private MovieRentalContext context;

        public RentRepository(MovieRentalContext context)
        {
            this.context = context;
        }

        public IEnumerable<Rent> GetRents()
        {
            return context.Rentals.ToList();
        }

        public Rent GetRent(int id)
        {
            return context.Rentals.Find(id);
        }

        public void InsertRent(Rent rent)
        {
            context.Rentals.Add(rent);
        }

        public void DeleteRent(int rentID)
        {
            Rent rent = context.Rentals.Find(rentID);
            context.Rentals.Remove(rent);
        }

        public void UpdateRent(Rent rent)
        {
            context.Entry(rent).State = EntityState.Modified;
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
