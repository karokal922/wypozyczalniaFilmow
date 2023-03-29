using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Models;

namespace wypozyczalniaDAL.Interfaces
{
    public interface IMovieRepository : IDisposable
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovie(int id);
        void InsertMovie(Movie movie);
        void DeleteMovie(int id);
        void UpdateMovie(Movie movie);
        void Save();

    }
}
