using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;

namespace wypozyczalniaDAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private MovieRentalContext context = new MovieRentalContext();
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<Movie> movieRepository;
        private GenericRepository<Payment> paymentRepository;
        private GenericRepository<Rate> rateRepository;
        private GenericRepository<Rent> rentRepository;
        private GenericRepository<User> userRepository;

        public UnitOfWork(MovieRentalContext context) 
        {
            this.context = context;
            this.movieRepository = new GenericRepository<Movie>(context);
            this.categoryRepository = new GenericRepository<Category>(context);
            this.paymentRepository = new GenericRepository<Payment>(context);
            this.rateRepository = new GenericRepository<Rate>(context);
            this.rentRepository = new GenericRepository<Rent>(context);
            this.userRepository = new GenericRepository<User>(context);
        }
        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;
            }
        }

        public GenericRepository<Movie> MovieRepository
        {
            get
            {
                if (this.movieRepository == null)
                {
                    this.movieRepository = new GenericRepository<Movie>(context);
                }
                return movieRepository;
            }
        }

        public GenericRepository<Payment> PaymentRepository
        {
            get
            {
                if (this.paymentRepository == null)
                {
                    this.paymentRepository = new GenericRepository<Payment>(context);
                }
                return paymentRepository;
            }
        }
        public GenericRepository<Rate> RateRepository
        {
            get
            {

                if (this.rateRepository == null)
                {
                    this.rateRepository = new GenericRepository<Rate>(context);
                }
                return rateRepository;
            }
        }
        public GenericRepository<Rent> RentRepository
        {
            get
            {

                if (this.rentRepository == null)
                {
                    this.rentRepository = new GenericRepository<Rent>(context);
                }
                return rentRepository;
            }
        }
        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
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
