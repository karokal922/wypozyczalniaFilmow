using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;

namespace wypozyczalniaDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public GenericRepository<Category> CategoryRepository { get; }
        public GenericRepository<Movie> MovieRepository { get; }
        public GenericRepository<Payment> PaymentRepository { get; }
        public GenericRepository<Rate> RateRepository { get; }
        public GenericRepository<Rent> RentRepository { get; }
        public GenericRepository<User> UserRepository { get; }
        public void Save();
    }
}
