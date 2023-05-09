using Microsoft.EntityFrameworkCore;
using System.Reflection;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;
using wypozyczalniaDAL;
using Microsoft.Extensions.DependencyInjection;

namespace TestProjectDAL.Tests
{
    public class UnitTestRateRepo
    {

        [Fact]
        public void TestGetRates()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<MovieRentalContext>()
                .UseInMemoryDatabase("Testowa")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            using (var inMemoryDbContext = new MovieRentalContext(options))
            {
                RateRepository rateRepository = new RateRepository(inMemoryDbContext);

                Assert.Empty(rateRepository.GetRates());

                rateRepository.InsertRate(new Rate { Id_Rate = 1, Movie_ID = 1, User_ID = 1, Comment = "xxx", _Rate = 8.7 });
                rateRepository.Save();
                Assert.Equal(1, rateRepository.GetRates().Count());
            }
        }
    }
}