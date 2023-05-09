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
        private MovieRentalContext context /*= new MovieRentalContext()*/;
        //private GenericRepository<Category> categoryRepository;
        //private GenericRepository<Movie> movieRepository;
        //private GenericRepository<Payment> paymentRepository;
        //private GenericRepository<Rate> rateRepository;
        //private GenericRepository<Rent> rentRepository;
        //private GenericRepository<User> userRepository;
        private ICategoryRepository categoryRepository;
        private IMovieRepository movieRepository;
        private IPaymentRepository paymentRepository;
        private IRateRepository rateRepository;
        private IRentRepository rentRepository;
        private IUserRepository userRepository;

        public UnitOfWork(MovieRentalContext context, ICategoryRepository categoryRepository, IMovieRepository movieRepository,
                          IPaymentRepository paymentRepository, IRateRepository rateRepository, IRentRepository rentRepository,
                          IUserRepository userRepository)
        {
            this.context = context;
            this.categoryRepository = categoryRepository;
            this.movieRepository = movieRepository;
            this.paymentRepository = paymentRepository;
            this.rateRepository = rateRepository;
            this.rentRepository = rentRepository;
            this.userRepository = userRepository;
        }
        public UnitOfWork(MovieRentalContext context)
        {
            this.context = context;
        }
        public UnitOfWork(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public UnitOfWork(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public UnitOfWork(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        public UnitOfWork(IRateRepository rateRepository)
        {
            this.rateRepository = rateRepository;
        }

        public UnitOfWork(IRentRepository rentRepository)
        {
            this.rentRepository = rentRepository;
        }

        public UnitOfWork(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public ICategoryRepository CategoryRepository//GenericRepository<Category> CategoryRepository
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

        public IMovieRepository MovieRepository//GenericRepository<Movie> MovieRepository
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

        public IPaymentRepository PaymentRepository//GenericRepository<Payment> PaymentRepository
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
        public IRateRepository RateRepository//GenericRepository<Rate> RateRepository
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
        public IRentRepository RentRepository//GenericRepository<Rent> RentRepository
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
        public IUserRepository UserRepository//GenericRepository<User> UserRepository
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
