﻿using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using MovieRental.BLL.Interfaces;
using MovieRental.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Services
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

            if (category_id != -1)
            {
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
            }
            else
            {
                return movies;
            }
            return result;
        }
        public IEnumerable<Movie> SortMoviesByAvgRatingsInGivenYear(int year)
        {

            var movies = unitOfWork.MovieRepository.GetMovies().Where(m => m.Premiere.Year == year)
                .OrderByDescending(m => m.Rates.Count() > 0 ? m.Rates.Average(r => r.RateValue) : 0).ToList();
            return movies;
        }
    }
}
