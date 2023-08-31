using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Models
{
    public class MovieRentalContext : DbContext
    {
        public MovieRentalContext() {}
        public MovieRentalContext(DbContextOptions options) : base(options) {}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rent> Rentals { get; set; }
        public DbSet<Rate> Ratings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Categories)
                .WithMany(c => c.Movies)
                .UsingEntity(j => j.ToTable("MovieCategory"));

            modelBuilder.Entity<Rate>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Rates)
                .HasForeignKey(r => r.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rate>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rates)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rent>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rents)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Rent>()
                .HasMany(r => r.Movies)
                .WithOne(m => m.Rent)
                .HasForeignKey(m => m.RentId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Rent)
                .WithOne(r => r.Payment)
                .HasForeignKey<Payment>(p => p.RentId)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MovieRentalv3;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
