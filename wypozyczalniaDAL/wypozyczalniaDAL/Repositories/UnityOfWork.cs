using Microsoft.Identity.Client;
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
        //private GenericRepository<Category> categoryRepository;
        //private GenericRepository<Movie> movieRepository;
        //private GenericRepository<Payment> paymentRepository;
        //private GenericRepository<Rate> rateRepository;
        //private GenericRepository<Rent> rentRepository;
        //private GenericRepository<User> userRepository;
        private CategoryRepository categoryRepository;
        private MovieRepository movieRepository;
        private PaymentRepository paymentRepository;
        private RateRepository rateRepository;
        private RentRepository rentRepository;
        private UserRepository userRepository;

        public UnitOfWork(MovieRentalContext context) 
        {
            this.context = context;
            this.movieRepository = new MovieRepository(context);//new GenericRepository<Movie>(context);
            this.categoryRepository = new CategoryRepository(context);//new GenericRepository<Category>(context);
            this.paymentRepository = new PaymentRepository(context);//new GenericRepository<Payment>(context);
            this.rateRepository = new RateRepository(context);//new GenericRepository<Rate>(context);
            this.rentRepository = new RentRepository(context);//new GenericRepository<Rent>(context);
            this.userRepository = new UserRepository(context);//new GenericRepository<User>(context);
        }
        public CategoryRepository CategoryRepository//GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(context);//new GenericRepository<Category>(context);
                }
                return categoryRepository;
            }
        }

        public MovieRepository MovieRepository//GenericRepository<Movie> MovieRepository
        {
            get
            {
                if (this.movieRepository == null)
                {
                    this.movieRepository = new MovieRepository(context);//new GenericRepository<Movie>(context);
                }
                return movieRepository;
            }
        }

        public PaymentRepository PaymentRepository//GenericRepository<Payment> PaymentRepository
        {
            get
            {
                if (this.paymentRepository == null)
                {
                    this.paymentRepository = new PaymentRepository(context);//new GenericRepository<Payment>(context);
                }
                return paymentRepository;
            }
        }
        public RateRepository RateRepository//GenericRepository<Rate> RateRepository
        {
            get
            {

                if (this.rateRepository == null)
                {
                    this.rateRepository = new RateRepository(context);//new GenericRepository<Rate>(context);
                }
                return rateRepository;
            }
        }
        public RentRepository RentRepository//GenericRepository<Rent> RentRepository
        {
            get
            {

                if (this.rentRepository == null)
                {
                    this.rentRepository = new RentRepository(context);//new GenericRepository<Rent>(context);
                }
                return rentRepository;
            }
        }
        public UserRepository UserRepository//GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);//new GenericRepository<User>(context);
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
