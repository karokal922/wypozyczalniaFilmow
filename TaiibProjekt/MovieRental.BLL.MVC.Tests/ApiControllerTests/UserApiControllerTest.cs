using Moq;
using MovieRental.BLL.Interfaces;
using MovieRental.BLL.MVC.Controllers;
using MovieRental.BLL.Services;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.MVC.Tests.ApiControllerTests
{
    public class UserApiControllerTest
    {
        [Fact]
        public void TestGetUsersWithRateCountSortedAction()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();

            var lista = new List<UserRateViewModel>
            {
                new UserRateViewModel{ Name = "Jan", Surname = "Dziki", RateCount = 30 },
                new UserRateViewModel{ Name = "Karol", Surname = "Taki", RateCount = 10 },
                new UserRateViewModel{ Name = "Paweł", Surname = "Jaki", RateCount = 20 },
                new UserRateViewModel{ Name = "Piotr", Surname = "Gdzie", RateCount = 123 }
            };

            mockUserService.Setup(s => s.GetUsersWithRateCountSorted()).Returns(lista);

            UserApiController usersApiController = new UserApiController(mockUserService.Object);

            Assert.Same(lista, usersApiController.GetUsersWithRateCountSorted());
        }

        [Fact]
        public void TestGetUsersWithRateCountSortedAction_NoUsersWithRates()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();

            var emptyList = new List<UserRateViewModel>();

            mockUserService.Setup(s => s.GetUsersWithRateCountSorted()).Returns(emptyList);

            UserApiController usersApiController = new UserApiController(mockUserService.Object);

            var result = usersApiController.GetUsersWithRateCountSorted();

            Assert.Empty(result);
        }


        [Fact]
        public void TestGetUsersByNameSortedAction()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();

            var lista = new List<User>
            {
                new User {Id_User = 1,Rates = new List<Rate>(),Name = "Jan",Surname = "Hoe"},
                new User {Id_User = 2,Rates = new List<Rate>(),Name = "Paweł",Surname = "Kowal"},
                new User {Id_User = 3, Rates = new List<Rate>(),Name = "Michał",Surname = "Jankowski"}
            };

            mockUserService.Setup(s => s.GetUsersByNameSorted("Jan")).Returns(lista);

            UserApiController usersApiController = new UserApiController(mockUserService.Object);
            Assert.Equal(lista, usersApiController.GetUsersByNameSorted("Jan"));
        }

        [Fact]
        public void TestGetUsersByNameSortedAction_WhenNameExists()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();

            var lista = new List<User>
            {
                new User { Id_User = 1, Rates = new List<Rate>(), Name = "Jan", Surname = "Hoe" },
                new User { Id_User = 2, Rates = new List<Rate>(), Name = "Jan", Surname = "Kowal" },
            };

            mockUserService.Setup(s => s.GetUsersByNameSorted("Jan")).Returns(lista);

            UserApiController usersApiController = new UserApiController(mockUserService.Object);

            var result = usersApiController.GetUsersByNameSorted("Jan");

            Assert.Equal(lista, result);
        }

        [Fact]
        public void TestGetUsersByNameSortedAction_WhenNameDoesNotExist()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();

            var emptyList = new List<User>();

            mockUserService.Setup(s => s.GetUsersByNameSorted("NonExistentName")).Returns(emptyList);

            UserApiController usersApiController = new UserApiController(mockUserService.Object);

            var result = usersApiController.GetUsersByNameSorted("NonExistentName");

            Assert.Empty(result);
        }

        [Fact]
        public void TestGetUsersWithRateCountSortedAction_NoUsers()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();

            var emptyList = new List<UserRateViewModel>();

            mockUserService.Setup(s => s.GetUsersWithRateCountSorted()).Returns(emptyList);

            UserApiController usersApiController = new UserApiController(mockUserService.Object);

            var result = usersApiController.GetUsersWithRateCountSorted();

            Assert.Empty(result);
        }

        [Fact]
        public void TestGetUsersByNameSortedAction_WithMultipleMatches()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();

            var userList = new List<User>
            {
                new User { Id_User = 1, Rates = new List<Rate>(), Name = "Jan", Surname = "Kowalski" },
                new User { Id_User = 2, Rates = new List<Rate>(), Name = "Jan", Surname = "Nowak" },
            };

            mockUserService.Setup(s => s.GetUsersByNameSorted("Jan")).Returns(userList);

            UserApiController usersApiController = new UserApiController(mockUserService.Object);

            var result = usersApiController.GetUsersByNameSorted("Jan");

            Assert.Equal(userList, result);
        }

    }
}
