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
                var movie = new Movie
                {
                    Description = "xxx",
                    Director = "Jan Nowak",
                    Id_Movie = 1,
                    Premiere = new DateTime(2019, 10, 10),
                    Rates = null,
                    Title = "Kot w butach",
                    Categories = new List<Category> { new Category { CategoryName = "Horror", Id_Category = 1, Movies = new List<Movie>() } }
                };
                var user = new User
                {
                    Id_User = 1,
                    Name = "test",
                    Surname = "test",
                    Rates = null,
                    Rents = null
                };
                rateRepository.InsertRate(new Rate { Id_Rate = 1, MovieId = 1, UserId = 1, Comment = "xxx", RateValue = 8.7, User = user, Movie = movie });
                rateRepository.Save();
                Assert.Equal(1, rateRepository.GetRates().Count());
            }
        }
    }
}
