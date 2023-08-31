using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Repositories
{
    public class MovieRepository : IMovieRepository, IDisposable
    {
        private MovieRentalContext context;

        public MovieRepository(MovieRentalContext context)
        {
            this.context = context;
        }
        public IEnumerable<Movie> GetMovies()
        {
            return context.Movies
                .Include(categories => categories.Categories)
                .Include(rent => rent.Rent)
                .Include(rate => rate.Rates)
                .ToList();
        }

        public Movie GetMovie(int id)
        {
            return context.Movies
                .Where(m => m.Id_Movie == id)
                .Include(categories => categories.Categories)
                .Include(rent => rent.Rent)
                .Include(rate => rate.Rates)
                .FirstOrDefault();
        }

        public int InsertMovie(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
            return movie.Id_Movie;
        }

        public void DeleteMovie(int movieID)
        {
            Movie movie = context.Movies.Find(movieID);
            context.Movies.Remove(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            context.Entry(movie).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
