using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;

namespace MovieRentalBLL
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Movie> GetMoviesByCategory(Category category)
        {
            var movies = unitOfWork.MovieRepository.GetMovies();

            //List<Movie> result = new List<Movie>();

            //foreach (Movie movie in movies)
            //{
            //    foreach (Category movie_category in movie.Categories)
            //    {
            //        if (movie_category == category)
            //        {
            //            result.Add(movie);
            //        }
            //    }
            //}
            //return result;

            return (from Movie movie in movies
                    from Category movie_category in movie.Categories
                    where movie_category == category
                    select movie).ToList();

            

        }
        public IEnumerable<Movie> SortMoviesByRatingsInGivenYear(int year)
        {
            var movies = unitOfWork.MovieRepository.GetMovies().Where(m => m.Premiere.Year == year).ToList();

            return (from movie in movies
                    where movie.Premiere.Year == year
                    orderby movie.Ratings.DefaultIfEmpty().Average(rate => rate?._Rate ?? 0.0) descending
                    select movie).ToList();
        }

    }
}
