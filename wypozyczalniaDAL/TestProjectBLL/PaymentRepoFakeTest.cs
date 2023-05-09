using MovieRentalBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDAL;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;

namespace TestProjectBLL
{
    public class PaymentRepoFakeTest
    {
        [Fact]
        public void GetMoviesByCategoryTest()
        {
            var movieRepo = new MovieRepoFake();
            var unityOfWork = new UnitOfWork(movieRepo);
            var movieBLL = new MovieService(unityOfWork);

        }
    }
}
