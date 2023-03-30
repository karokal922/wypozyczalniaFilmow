using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalniaDAL.Models
{
    public class MovieRentalContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rent> Rentals { get; set; }
        public DbSet<Rate> Ratings { get; set; }
        public void OnModelCreating(DbContextOptionsBuilder modelBuilder)
        {
            modelBuilder.UseSqlServer();
        }

    }
}
