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
    }
}
