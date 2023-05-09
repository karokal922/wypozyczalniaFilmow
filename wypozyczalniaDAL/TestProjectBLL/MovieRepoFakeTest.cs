using Moq;
using MovieRentalBLL.Services;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;

namespace TestDAL
{
    public class MovieRepoFakeTest
    {
        [Fact]
        public void GetMoviesByCategoryTest()
        {
            var movieRepo = new MovieRepoFake();
            var unityOfWork = new UnitOfWork(movieRepo);
            var movieBLL = new MovieService(unityOfWork);

            var movie1 = new Movie
            {
                Description = "xxx",
                Director = "Jan Nowak",
                Id_Movie = 1,
                Premiere = new DateTime(2019, 10, 10),
                Ratings = null,
                Title = "Kot w butach",
                Categories = new List<Category> { new Category { CategoryName = "Horror", Id_Category = 1, Movies = new List<Movie>() } }
            };

            var movie2 = new Movie
            {
                Description = "yyy",
                Director = "Piotr Skowyrski",
                Id_Movie = 2,
                Premiere = new DateTime(2009, 2, 24),
                Ratings = null,
                Title = "HeadShot",
                Categories = new List<Category> { new Category { CategoryName = "Film akcji", Id_Category = 2, Movies = null } }
            };

            var movie3 = new Movie
            {
                Description = "zzz",
                Director = "Joanna Jop",
                Id_Movie = 3,
                Premiere = new DateTime(2015, 8, 1),
                Ratings = null,
                Title = "Nielegalni",
                Categories = new List<Category> { new Category { CategoryName = "Komedia", Id_Category = 3, Movies = null } }
            };


            movieRepo.InsertMovie(movie1);
            movieRepo.InsertMovie(movie2);
            movieRepo.InsertMovie(movie3);

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
                        Ratings = null,
                        Title = "Kot w butach",
                        Categories = new List<Category> { new Category { CategoryName = "Horror", Id_Category = 1, Movies = new List<Movie>() } }
                    },
                    new Movie
                    {
                        Description = "yyy",
                        Director = "Piotr Skowyrski",
                        Id_Movie = 2,
                        Premiere = new DateTime(2009, 2, 24),
                        Ratings = null,
                        Title = "HeadShot",
                        Categories = new List<Category> { new Category { CategoryName = "Film akcji", Id_Category = 2, Movies = null } }
                    },
                    new Movie
                    {
                        Description = "zzz",
                        Director = "Joanna Jop",
                        Id_Movie = 3,
                        Premiere = new DateTime(2015, 8, 1),
                        Ratings = null,
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