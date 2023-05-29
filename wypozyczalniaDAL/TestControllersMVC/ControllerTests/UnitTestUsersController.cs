using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieRentalBLL.Interfaces;
using TestBLL.Controllers;
using wypozyczalniaDAL.Models;

namespace TestControllersMVC.ControllerTests
{
    public class UnitTestUsersController
    {
        [Fact]
        public void TestGetUsersWithRateCountSortedAction() 
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();

            var lista = new List<object>
            {
                new { Name = "Jan", Surname = "Dziki", RateCount = 30 },
                new { Name = "Karol", Surname = "Taki", RateCount = 10 },
                new { Name = "Paweł", Surname = "Jaki", RateCount = 20 },
                new { Name = "Piotr", Surname = "Gdzie", RateCount = 123 }
            };

            mockUserService
               .Setup(s => s.GetUsersWithRateCountSorted())
               .Returns(lista);

            UserController usersController = new UserController(mockUserService.Object);


            var result = usersController.ShowUsersWithRateCount();

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Same(lista, viewResult.ViewData["UsersWithRateCount"]);
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
        
            mockUserService
               .Setup(s => s.GetUsersByNameSorted("Jan"))
               .Returns(lista);

            UserController usersController = new UserController(mockUserService.Object);


            var result = usersController.ShowUsers("Jan");

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Same(lista, viewResult.ViewData["Users"]);
        }
    }
}
