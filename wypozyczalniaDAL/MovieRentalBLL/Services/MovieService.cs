using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MovieRentalBLL.Interfaces;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;

namespace MovieRentalBLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetAllCategories()
        {

            return unitOfWork.CategoryRepository.GetCategories();
        }

        public IEnumerable<Movie> GetMoviesByCategory(int category_id)
        {
            var movies = unitOfWork.MovieRepository.GetMovies();
            
            
            
            List<Movie> result = new List<Movie>();
            Category category = unitOfWork.CategoryRepository.GetCategory(category_id);

            foreach (Movie movie in movies)
            {
                if (movie.Categories != null)
                {
                    foreach (Category movie_category in movie.Categories)
                    {
                        if (movie_category == category)
                        {
                            result.Add(movie);
                        }
                    }
                }
            }

            return result;
 

        }
        public IEnumerable<Movie> SortMoviesByRatingsInGivenYear(int year)
        {
            var movies = unitOfWork.MovieRepository.GetMovies().Where(m => m.Premiere.Year == year).ToList();

            return (from movie in movies
                    where movie.Premiere.Year == year
                    //orderby movie.Ratings.Average(rate => rate._Rate) descending
                    select movie).ToList();
        }

    }
}
