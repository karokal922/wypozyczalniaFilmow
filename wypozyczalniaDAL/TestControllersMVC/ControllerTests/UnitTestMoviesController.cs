using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieRentalBLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBLL.Controllers;
using wypozyczalniaDAL.Models;

namespace TestControllersMVC.ControllerTests
{
    public class UnitTestMoviesController
    {
        [Fact]
        public void TestGetMoviesByCategoryAction()
        {
            Mock<IMovieService> mockMovieService = new Mock<IMovieService>();

            var category1 = new Category { Id_Category = 1, CategoryName = "Action" };
            var category2 = new Category { Id_Category = 2, CategoryName = "Comedy" };

            var movie1 = new Movie
            {
                Id_Movie = 1,
                Categories = new List<Category> { category1 },
                Title = "Movie 1",
                Director = "Director 1",
                Premiere = new DateTime(2022, 5, 10),
                Ratings = new List<Rate>
                {
                    new Rate { Id_Rate = 1, Movie_ID = 1, User_ID = 1, _Rate = 8.5, Comment = "Good movie" },
                    new Rate { Id_Rate = 2, Movie_ID = 1, User_ID = 2, _Rate = 9.0, Comment = "Awesome!" }
                },
                Description = "Description of Movie 1"
            };

            var movie2 = new Movie
            {
                Id_Movie = 2,
                Categories = new List<Category> { category1, category2 },
                Title = "Movie 2",
                Director = "Director 2",
                Premiere = new DateTime(2021, 12, 25),
                Ratings = new List<Rate>
                {
                    new Rate { Id_Rate = 3, Movie_ID = 2, User_ID = 1, _Rate = 7.8, Comment = "Entertaining" },
                    new Rate { Id_Rate = 4, Movie_ID = 2, User_ID = 3, _Rate = 6.5, Comment = "Not my favorite" }
                },
                Description = "Description of Movie 2"
            };

            var movies = new List<Movie> { movie1, movie2 };

            mockMovieService
               .Setup(s => s.GetMoviesByCategory(1))
               .Returns(movies);

            MovieController movieController = new MovieController(mockMovieService.Object);

            var result = movieController.GetAllFilsWithGivenCategory(1);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Same(movies, viewResult.ViewData["MoviesFromCategory"]);
        }
        [Fact]
        public void TestSortMoviesByRatingsInGivenYearAction()
        {
            Mock<IMovieService> mockMovieService = new Mock<IMovieService>();

            var category1 = new Category { Id_Category = 1, CategoryName = "Action" };
            var category2 = new Category { Id_Category = 2, CategoryName = "Comedy" };

            var movie1 = new Movie
            {
                Id_Movie = 1,
                Categories = new List<Category> { category1 },
                Title = "Movie 1",
                Director = "Director 1",
                Premiere = new DateTime(2021, 5, 10),
                Ratings = new List<Rate>
                {
                    new Rate { Id_Rate = 1, Movie_ID = 1, User_ID = 1, _Rate = 8.5, Comment = "Good movie" },
                    new Rate { Id_Rate = 2, Movie_ID = 1, User_ID = 2, _Rate = 9.0, Comment = "Awesome!" }
                },
                Description = "Description of Movie 1"
            };

            var movie2 = new Movie
            {
                Id_Movie = 2,
                Categories = new List<Category> { category1, category2 },
                Title = "Movie 2",
                Director = "Director 2",
                Premiere = new DateTime(2021, 12, 25),
                Ratings = new List<Rate>
                {
                    new Rate { Id_Rate = 3, Movie_ID = 2, User_ID = 1, _Rate = 7.8, Comment = "Entertaining" },
                    new Rate { Id_Rate = 4, Movie_ID = 2, User_ID = 3, _Rate = 6.5, Comment = "Not my favorite" }
                },
                Description = "Description of Movie 2"
            };
            var movie3 = new Movie
            {
                Id_Movie = 3,
                Categories = new List<Category> { category1, category2 },
                Title = "Movie 3",
                Director = "Director 3",
                Premiere = new DateTime(2021, 12, 25),
                Ratings = new List<Rate>
                {
                    new Rate { Id_Rate = 5, Movie_ID = 3, User_ID = 2, _Rate = 6.7, Comment = "Entertaining" },
                    new Rate { Id_Rate = 6, Movie_ID = 3, User_ID = 3, _Rate = 7.3, Comment = "Not my favorite" }
                },
                Description = "Description of Movie 3"
            };
            var movies = new List<Movie> { movie1, movie2, movie3 };

            mockMovieService
               .Setup(s => s.SortMoviesByRatingsInGivenYear(2021))
               .Returns(movies);

            MovieController movieController = new MovieController(mockMovieService.Object);

            var result = movieController.ShowMovies(2021);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Same(movies, viewResult.ViewData["Movies"]);
        }
    }
}
