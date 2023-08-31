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
    public class RateRepository : IRateRepository, IDisposable
    {
        private MovieRentalContext context;

        public RateRepository(MovieRentalContext context)
        {
            this.context = context;
        }

        public IEnumerable<Rate> GetRates()
        {
            return context.Ratings
                .Include(m => m.Movie)
                .Include(u => u.User)
                .ToList();
        }

        public Rate GetRate(int id)
        {
            return context.Ratings
                .Where(r => r.Id_Rate == id)
                .Include(m => m.Movie)
                .Include(u => u.User)
                .FirstOrDefault();
        }

        public void InsertRate(Rate rate)
        {
            context.Ratings.Add(rate);
        }

        public void DeleteRate(int rateID)
        {
            Rate rate = context.Ratings.Find(rateID);
            context.Ratings.Remove(rate);
        }

        public void UpdateRate(Rate rate)
        {
            context.Entry(rate).State = EntityState.Modified;
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
