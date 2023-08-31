using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieRental.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository CategoryRepository { get; }
        public IMovieRepository MovieRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IRateRepository RateRepository { get; }
        public IRentRepository RentRepository { get; }
        public IUserRepository UserRepository { get; }
        public void Save();
    }
}
