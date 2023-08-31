using Microsoft.EntityFrameworkCore;
using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Repositories
{
    public class RentRepository : IRentRepository, IDisposable
    {
        private MovieRentalContext context;

        public RentRepository(MovieRentalContext context)
        {
            this.context = context;
        }

        public IEnumerable<Rent> GetRents()
        {
            return context.Rentals
                .Include(p => p.Payment)
                .Include(m => m.Movies)
                .Include(u => u.User)
                .ToList();
        }

        public Rent GetRent(int id)
        {
            return context.Rentals
                .Where(r=>r.Id_Rent==id)
                .Include(p => p.Payment)
                .Include(m => m.Movies)
                .Include(u => u.User)
                .FirstOrDefault();
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
