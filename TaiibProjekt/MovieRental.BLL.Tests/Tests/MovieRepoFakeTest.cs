using Moq;
using MovieRental.BLL.Services;
using MovieRental.BLL.Tests.Fakes;
using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using MovieRental.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Tests.Tests
{
    public class MovieRepoFakeTest
    {
        [Fact]
        public void GetMoviesByCategoryTest()
        {
            Mock<IMovieRepository> mockMovieRepo = new Mock<IMovieRepository>();
            Mock<ICategoryRepository> mockCategoryRepo = new Mock<ICategoryRepository>();

            var movieRepo = new MovieRepoFake();
            var unityOfWork = new UnitOfWork(movieRepo);
            var movieBLL = new MovieService(unityOfWork);

            var movie1 = new Movie
            {
                Description = "xxx",
                Director = "Jan Nowak",
                Id_Movie = 1,
                Premiere = new DateTime(2019, 10, 10),
                Rates = null,
                Title = "Kot w butach",
                Categories = new List<Category> { new Category { CategoryName = "Horror", Id_Category = 1, Movies = new List<Movie>() } }
            };

            var movie2 = new Movie
            {
                Description = "yyy",
                Director = "Piotr Skowyrski",
                Id_Movie = 2,
                Premiere = new DateTime(2009, 2, 24),
                Rates = null,
                Title = "HeadShot",
                Categories = new List<Category> { new Category { CategoryName = "Film akcji", Id_Category = 2, Movies = null } }
            };

            var movie3 = new Movie
            {
                Description = "zzz",
                Director = "Joanna Jop",
                Id_Movie = 3,
                Premiere = new DateTime(2015, 8, 1),
                Rates = null,
                Title = "Nielegalni",
                Categories = new List<Category> { new Category { CategoryName = "Komedia", Id_Category = 3, Movies = null } }
            };

            movieRepo.InsertMovie(movie1);
            movieRepo.InsertMovie(movie2);
            movieRepo.InsertMovie(movie3);

            mockMovieRepo.Setup(m => m.GetMovies()).Returns(movieRepo.GetMovies());//unitOfWork.CategoryRepository.GetCategory(category_id);
            mockCategoryRepo.Setup(c => c.GetCategory(It.IsAny<int>())).Returns(movie1.Categories.First());

            var result = movieBLL.GetMoviesByCategory(1);

            Assert.Equal(0, result.Count());
        }
        [Fact]
        public void GetMoviesByCategoryTestMoq()
        {
            Mock<IMovieRepository> mockMovieRepo = new Mock<IMovieRepository>();
            mockMovieRepo.Setup(x => x.GetMovies())
                .Returns(new List<Movie>
                {
                        new Movie{
                            Description = "xxx",
                            Director = "Jan Nowak",
                            Id_Movie = 1,
                            Premiere = new DateTime(2019, 10, 10),
                            Rates = null,
                            Title = "Kot w butach",
                            Categories = new List<Category> { new Category { CategoryName = "Horror", Id_Category = 1, Movies = new List<Movie>() } }
                        },
                        new Movie
                        {
                            Description = "yyy",
                            Director = "Piotr Skowyrski",
                            Id_Movie = 2,
                            Premiere = new DateTime(2009, 2, 24),
                            Rates = null,
                            Title = "HeadShot",
                            Categories = new List<Category> { new Category { CategoryName = "Film akcji", Id_Category = 2, Movies = null } }
                        },
                        new Movie
                        {
                            Description = "zzz",
                            Director = "Joanna Jop",
                            Id_Movie = 3,
                            Premiere = new DateTime(2015, 8, 1),
                            Rates = null,
                            Title = "Nielegalni",
                            Categories = new List<Category> { new Category { CategoryName = "Komedia", Id_Category = 3, Movies = null } }
                        }
                });

            var unityOfWork = new UnitOfWork(mockMovieRepo.Object);
            var movieBLL = new MovieService(unityOfWork);

            var result = movieBLL.GetMoviesByCategory(1);

            Assert.Equal(0, result.Count());
        }
        [Fact]
        public void GetMoviesByCategory_Should_Return_Empty_List_When_No_Movies_In_Category()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var categoryId = 1;
            var category = new Category { Id_Category = categoryId, CategoryName = "Action" };
            var moviesInDifferentCategory = new List<Movie>
            {
                new Movie { Id_Movie = 4, Title = "Movie1", Categories = new List<Category> { new Category { Id_Category = 2, CategoryName = "Drama" } } },
                new Movie { Id_Movie = 5, Title = "Movie2", Categories = new List<Category> { new Category { Id_Category = 3, CategoryName = "Sci-Fi" } } }
            };

            mockUnitOfWork.Setup(u => u.CategoryRepository.GetCategory(categoryId)).Returns(category);
            mockUnitOfWork.Setup(u => u.MovieRepository.GetMovies()).Returns(moviesInDifferentCategory);
            var movieService = new MovieService(mockUnitOfWork.Object);

            var result = movieService.GetMoviesByCategory(categoryId);

            Assert.Empty(result);
        }

        [Fact]
        public void GetMoviesByCategory_ShouldReturnEmptyListWhenCategoryDoesNotExist()
        {
            Mock<IMovieRepository> mockMovieRepo = new Mock<IMovieRepository>();
            mockMovieRepo.Setup(x => x.GetMovies())
                .Returns(new List<Movie>
                {
                        new Movie{
                            Description = "xxx",
                            Director = "Jan Nowak",
                            Id_Movie = 1,
                            Premiere = new DateTime(2019, 10, 10),
                            Rates = null,
                            Title = "Kot w butach",
                            Categories = new List<Category> { new Category { CategoryName = "Horror", Id_Category = 1, Movies = new List<Movie>() } }
                        },
                        new Movie
                        {
                            Description = "yyy",
                            Director = "Piotr Skowyrski",
                            Id_Movie = 2,
                            Premiere = new DateTime(2009, 2, 24),
                            Rates = null,
                            Title = "HeadShot",
                            Categories = new List<Category> { new Category { CategoryName = "Film akcji", Id_Category = 2, Movies = null } }
                        },
                        new Movie
                        {
                            Description = "zzz",
                            Director = "Joanna Jop",
                            Id_Movie = 3,
                            Premiere = new DateTime(2015, 8, 1),
                            Rates = null,
                            Title = "Nielegalni",
                            Categories = new List<Category> { new Category { CategoryName = "Komedia", Id_Category = 3, Movies = null } }
                        }
                });

            var unityOfWork = new UnitOfWork(mockMovieRepo.Object);
            var movieBLL = new MovieService(unityOfWork);

            var categoryId = 100;

            var result = movieBLL.GetMoviesByCategory(categoryId);

            Assert.Empty(result);
        }
        [Fact]
        public void GetMoviesByCategory_ShouldReturnEmptyListForInvalidCategory()
        {
            Mock<IMovieRepository> mockMovieRepo = new Mock<IMovieRepository>();
            mockMovieRepo.Setup(x => x.GetMovies())
                .Returns(new List<Movie>
                {
                        new Movie{
                            Description = "xxx",
                            Director = "Jan Nowak",
                            Id_Movie = 1,
                            Premiere = new DateTime(2019, 10, 10),
                            Rates = null,
                            Title = "Kot w butach",
                            Categories = new List<Category> { new Category { CategoryName = "Horror", Id_Category = 1, Movies = new List<Movie>() } }
                        },
                        new Movie
                        {
                            Description = "yyy",
                            Director = "Piotr Skowyrski",
                            Id_Movie = 2,
                            Premiere = new DateTime(2009, 2, 24),
                            Rates = null,
                            Title = "HeadShot",
                            Categories = new List<Category> { new Category { CategoryName = "Film akcji", Id_Category = 2, Movies = null } }
                        },
                        new Movie
                        {
                            Description = "zzz",
                            Director = "Joanna Jop",
                            Id_Movie = 3,
                            Premiere = new DateTime(2015, 8, 1),
                            Rates = null,
                            Title = "Nielegalni",
                            Categories = new List<Category> { new Category { CategoryName = "Komedia", Id_Category = 3, Movies = null } }
                        }
                });

            var unityOfWork = new UnitOfWork(mockMovieRepo.Object);
            var movieBLL = new MovieService(unityOfWork);

            var categoryId = 3; 

            var result = movieBLL.GetMoviesByCategory(categoryId);

            Assert.Empty(result);
        }

        [Fact]
        public void GetAllCategories_Should_Return_All_Categories()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var expectedCategories = new List<Category>
            {
                new Category { Id_Category = 1, CategoryName = "Action" },
                new Category { Id_Category = 2, CategoryName = "Comedy" }
            };

            mockUnitOfWork.Setup(u => u.CategoryRepository.GetCategories()).Returns(expectedCategories);
            var movieService = new MovieService(mockUnitOfWork.Object);

            var categories = movieService.GetAllCategories();

            Assert.Equal(expectedCategories, categories);
        }
        [Fact]
        public void GetMoviesByCategory_Should_Return_Movies_In_Category()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var categoryId = 1;
            var category = new Category { Id_Category = categoryId, CategoryName = "Action" };
            var moviesInCategory = new List<Movie>
            {
                new Movie { Id_Movie = 1, Title = "Movie1", Categories = new List<Category> { category } },
                new Movie { Id_Movie = 2, Title = "Movie2", Categories = new List<Category> { category } }
            };

            mockUnitOfWork.Setup(u => u.CategoryRepository.GetCategory(categoryId)).Returns(category);
            mockUnitOfWork.Setup(u => u.MovieRepository.GetMovies()).Returns(moviesInCategory);
            var movieService = new MovieService(mockUnitOfWork.Object);

            var result = movieService.GetMoviesByCategory(categoryId);

            Assert.Equal(moviesInCategory, result);
        }

        [Fact]
        public void SortMoviesByAvgRatingsInGivenYear_ShouldReturnSortedList()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var year = 2020;
            var movies = new List<Movie>
            {
                        new Movie{
                            Description = "xxx",
                            Director = "Director1",
                            Id_Movie = 1,
                            Premiere = new DateTime(2020, 1, 1),
                            Rates = new List<Rate> { new Rate { RateValue = 5 } },
                            Title = "Movie1",
                           
                        },
                        new Movie
                        {
                            Description = "yyy",
                            Director = "Director2",
                            Id_Movie = 2,
                            Premiere = new DateTime(2020, 2, 2),
                            Rates = new List<Rate> { new Rate { RateValue = 4 } },
                            Title = "Movie2",

                        },
                        new Movie
                        {
                            Description = "zzz",
                            Director = "Director3",
                            Id_Movie = 3,
                            Premiere = new DateTime(2020, 3, 3),
                            Rates = new List<Rate> { new Rate { RateValue = 4 } },
                            Title = "Movie3",
                           
                        }
            };

            mockUnitOfWork.Setup(u => u.MovieRepository.GetMovies()).Returns(movies);
            var movieService = new MovieService(mockUnitOfWork.Object);

            var result = movieService.SortMoviesByAvgRatingsInGivenYear(year);

            var expectedOrder = new List<int> { 1, 2, 3 }; 
            Assert.Equal(expectedOrder, result.Select(m => m.Id_Movie));
        }

        [Fact]
        public void SortMoviesByAvgRatingsInGivenYear_ShouldReturnEmptyListForInvalidYear()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var year = 2021;
            mockUnitOfWork.Setup(u => u.MovieRepository.GetMovies()).Returns(new List<Movie>());
            var movieService = new MovieService(mockUnitOfWork.Object);

            var result = movieService.SortMoviesByAvgRatingsInGivenYear(year);

            Assert.Empty(result);
        }
    }
}
