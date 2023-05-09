using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Repositories;
using TestProjectDAL.Dummies;

namespace TestProjectDAL.Tests
{
    public class UnitTestUnitOfWork
    {
        [Fact]
        public void TestUnitOfWork()
        {
            var categoryRepository = new CategoryRepoDummy();
            var movieRepository = new MovieRepoDummy();
            var paymentRepository = new PaymentRepoDummy();
            var rateRepository = new RateRepoDummy();
            var rentRepository = new RentRepoDummy();
            var userRepository = new UserRepoDummy();

            var unitOfWork = new UnitOfWork(null, categoryRepository, movieRepository, paymentRepository, rateRepository, rentRepository, userRepository);

            Assert.Same(categoryRepository, unitOfWork.CategoryRepository);
            Assert.Same(movieRepository, unitOfWork.MovieRepository);
            Assert.Same(paymentRepository, unitOfWork.PaymentRepository);
            Assert.Same(rateRepository, unitOfWork.RateRepository);
            Assert.Same(rentRepository, unitOfWork.RentRepository);
            Assert.Same(userRepository, unitOfWork.UserRepository);
        }
    }
}
