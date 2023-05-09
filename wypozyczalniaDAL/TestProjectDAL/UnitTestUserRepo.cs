using Microsoft.EntityFrameworkCore;
using System.Reflection;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;
using wypozyczalniaDAL;
using Microsoft.Extensions.DependencyInjection;

namespace TestProjectDAL
{
    public class UnitTestUserRepo
    {

        [Fact]
        public void TestGetUsers()
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
                UserRepository userRepository = new UserRepository(inMemoryDbContext);

                Assert.Empty(userRepository.GetUsers());
                
                userRepository.InsertUser(new wypozyczalniaDAL.Models.User { Id_User = 1, Name = "Jan", Surname = "Kowalski", Rates = null });
                userRepository.Save();
                Assert.Equal(1, userRepository.GetUsers().Count());
            }
        }
        [Fact]
        public void TestGetUser()
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
                UserRepository userRepository = new UserRepository(inMemoryDbContext);

                Assert.Empty(userRepository.GetUsers());
                User user = new User { Id_User = 3, Name = "Pawel", Surname = "Nowak", Rates = null };
                userRepository.InsertUser(new wypozyczalniaDAL.Models.User { Id_User = 1, Name = "Jan", Surname = "Kowalski", Rates = null });
                userRepository.InsertUser(new wypozyczalniaDAL.Models.User { Id_User = 2, Name = "Ola", Surname = "Alo", Rates = null });
                userRepository.InsertUser(user);
                userRepository.Save();
                Assert.Equal(user, userRepository.GetUser(3));
            }
        }
    }
}