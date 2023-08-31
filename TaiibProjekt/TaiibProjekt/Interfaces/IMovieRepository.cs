using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Interfaces
{
    public interface IMovieRepository : IDisposable
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovie(int id);
        int InsertMovie(Movie movie);
        void DeleteMovie(int id);
        void UpdateMovie(Movie movie);
        void Save();

    }
}
