using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Tests.Dummies
{
    public class MovieRepoDummy : IMovieRepository
    {
        void IMovieRepository.DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        Movie IMovieRepository.GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Movie> IMovieRepository.GetMovies()
        {
            throw new NotImplementedException();
        }

        int IMovieRepository.InsertMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        void IMovieRepository.Save()
        {
            throw new NotImplementedException();
        }

        void IMovieRepository.UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
