using Microsoft.AspNetCore.Mvc;
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

namespace MovieRental.BLL.MVC.Tests.ControllerTests
{
    public class UserControllerTest
    {
        [Fact]
        public void TestGetUsersWithRateCountSortedAction()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            UserController usersController = new UserController(mockUserService.Object);

            var lista = new List<UserRateViewModel>
            {
                new UserRateViewModel{ Name = "Jan", Surname = "Dziki", RateCount = 30 },
                new UserRateViewModel{ Name = "Karol", Surname = "Taki", RateCount = 10 },
                new UserRateViewModel{ Name = "Paweł", Surname = "Jaki", RateCount = 20 },
                new UserRateViewModel{ Name = "Piotr", Surname = "Gdzie", RateCount = 123 }
            };
            mockUserService.Setup(s => s.GetUsersWithRateCountSorted()).Returns(lista);
            var result = usersController.ShowUsersWithRateCount();

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Same(lista, viewResult.ViewData["UsersWithRateCount"]);
        }
        [Fact]
        public void TestGetUsersByNameSortedAction()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            UserController usersController = new UserController(mockUserService.Object);

            var lista = new List<User>
            {
                new User {Id_User = 1,Rates = new List<Rate>(),Name = "Jan",Surname = "Hoe"},
                new User {Id_User = 2,Rates = new List<Rate>(),Name = "Paweł",Surname = "Kowal"},
                new User {Id_User = 3, Rates = new List<Rate>(),Name = "Michał",Surname = "Jankowski"}
            };
            mockUserService.Setup(s => s.GetUsersByNameSorted("Jan")).Returns(lista);
            var result = usersController.ShowUsers("Jan");

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Same(lista, viewResult.ViewData["Users"]);
        }
    }
}
