using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieRental.BLL.Interfaces;
using MovieRental.BLL.MVC.Controllers;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.MVC.Tests.ControllerTests
{
    public class MovieControllerTest
    {
        private List<Category> getCategoriesList_Mock()
        {
            return new List<Category>
            {
                new Category { Id_Category = 1, CategoryName = "Action" },
                new Category { Id_Category = 2, CategoryName = "Comedy" }
            };
        }
        private List<Movie> getMovieList_Mock()
        {
            var categoryList = getCategoriesList_Mock();
            return new List<Movie>
            {
                new Movie
                {
                    Id_Movie = 1,
                    Categories = new List<Category> { categoryList[0] },
                    Title = "Movie 1",
                    Director = "Director 1",
                    Premiere = new DateTime(2022, 5, 10),
                    Rates = new List<Rate>
                    {
                        new Rate { Id_Rate = 1, MovieId = 1, UserId = 1, RateValue = 8.5, Comment = "Good movie" },
                        new Rate { Id_Rate = 2, MovieId = 1, UserId = 2, RateValue = 9.0, Comment = "Awesome!" }
                    },
                    Description = "Description of Movie 1"
                },
                new Movie
                {
                    Id_Movie = 2,
                    Categories = new List<Category> { categoryList[0], categoryList[1] },
                    Title = "Movie 2",
                    Director = "Director 2",
                    Premiere = new DateTime(2021, 12, 25),
                    Rates = new List<Rate>
                    {
                        new Rate { Id_Rate = 3, MovieId = 2, UserId = 1, RateValue = 7.8, Comment = "Entertaining" },
                        new Rate { Id_Rate = 4, MovieId = 2, UserId = 3, RateValue = 6.5, Comment = "Not my favorite" }
                    },
                    Description = "Description of Movie 2"
                }
            };
        }
        [Fact]
        public void TestGetMoviesByCategoryAction()
        {
            Mock<IMovieService> mockMovieService = new Mock<IMovieService>();
            var movies = getMovieList_Mock();

            mockMovieService.Setup(s => s.GetMoviesByCategory(1)).Returns(movies);
            MovieController movieController = new MovieController(mockMovieService.Object);

            var result = movieController.GetAllMoviesWithGivenCategory(1);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Same(movies, viewResult.ViewData["MoviesFromCategory"]);
        }
        [Fact]
        public void TestSortMoviesByRatingsInGivenYearAction()
        {
            Mock<IMovieService> mockMovieService = new Mock<IMovieService>();
            MovieController movieController = new MovieController(mockMovieService.Object);

            var categoryList = getCategoriesList_Mock();
            var movie3 = new Movie
            {
                Id_Movie = 3,
                Categories = new List<Category> { categoryList[0], categoryList[1] },
                Title = "Movie 3",
                Director = "Director 3",
                Premiere = new DateTime(2021, 12, 25),
                Rates = new List<Rate>
                {
                    new Rate { Id_Rate = 5, MovieId = 3, UserId = 2, RateValue = 6.7, Comment = "Entertaining" },
                    new Rate { Id_Rate = 6, MovieId = 3, UserId = 3, RateValue = 7.3, Comment = "Not my favorite" }
                },
                Description = "Description of Movie 3"
            };
            var movies = getMovieList_Mock();
            movies.Add(movie3);

            mockMovieService.Setup(s => s.SortMoviesByAvgRatingsInGivenYear(2021)).Returns(movies);

            var result = movieController.ShowMovies(2021);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Same(movies, viewResult.ViewData["Movies"]);
        }
    }
}
