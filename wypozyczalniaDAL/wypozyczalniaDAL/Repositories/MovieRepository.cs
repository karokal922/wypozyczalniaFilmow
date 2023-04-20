using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;

namespace wypozyczalniaDAL.Repositories
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
                .ToList();
        }

        public Movie GetMovie(int id)
        {
            return context.Movies
                .Where(m=>m.Id_Movie==id)
                .Include(categories => categories.Categories)
                .FirstOrDefault();
        }

        public void InsertMovie(Movie movie)
        {
            context.Movies.Add(movie);
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
