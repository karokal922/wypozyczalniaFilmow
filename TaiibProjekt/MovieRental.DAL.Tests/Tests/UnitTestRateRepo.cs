using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieRental.DAL.Models;
using MovieRental.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Tests.Tests
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

                rateRepository.InsertRate(new Rate { Id_Rate = 1, MovieId = 1, UserId = 1, Comment = "xxx", RateValue = 8.7 });
                rateRepository.Save();
                Assert.Equal(1, rateRepository.GetRates().Count());
            }
        }
    }
}
