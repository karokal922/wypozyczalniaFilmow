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

                userRepository.InsertUser(new User { Id_User = 1, Name = "Jan", Surname = "Kowalski", Rates = null, Rents = null });
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


                User user = new User { Id_User = 3, Name = "Pawel", Surname = "Nowak", Rates = null };
                userRepository.InsertUser(new User { Id_User = 1, Name = "Jan", Surname = "Kowalski", Rates = null });
                userRepository.InsertUser(new User { Id_User = 2, Name = "Ola", Surname = "Alo", Rates = null });
                userRepository.InsertUser(user);
                userRepository.Save();
                Assert.Equal(user, userRepository.GetUser(3));
            }
        }
        [Fact]
        public void TestDeleteUser()
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

                User user = new User { Id_User = 1, Name = "Jan", Surname = "Kowalski", Rates = null };
                User user1 = new User { Id_User = 2, Name = "Ola", Surname = "Alo", Rates = null };
                User user2 = new User { Id_User = 3, Name = "Pawel", Surname = "Nowak", Rates = null };
                userRepository.InsertUser(user);
                userRepository.InsertUser(user1);
                userRepository.InsertUser(user2);
                userRepository.Save();
                Assert.Equal(3, userRepository.GetUsers().Count());
                userRepository.DeleteUser(1);
                userRepository.Save();
                Assert.Equal(2, userRepository.GetUsers().Count());
            }
        }
    }
}
