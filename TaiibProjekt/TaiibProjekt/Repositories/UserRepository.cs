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
    public class UserRepository : IUserRepository, IDisposable
    {
        private MovieRentalContext context;

        public UserRepository(MovieRentalContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users
                .Include(r=>r.Rates)
                .Include(r=>r.Rents)
                .ToList();
        }

        public User GetUser(int id)
        {
            return context.Users
                .Where(u => u.Id_User == id)
                .Include(r => r.Rates)
                .Include(r => r.Rents)
                .FirstOrDefault();
        }

        public void InsertUser(User user)
        {
            context.Users.Add(user);
        }

        public void DeleteUser(int userID)
        {
            User user = context.Users.Find(userID);
            context.Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
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
