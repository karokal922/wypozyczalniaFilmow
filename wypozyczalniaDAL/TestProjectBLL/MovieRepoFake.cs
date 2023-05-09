using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;

namespace TestDAL
{
    public class MovieRepoFake : IMovieRepository
    {

        private readonly List<Movie> _movies = new List<Movie>();

        public IReadOnlyList<Movie> AllMovies => _movies.AsReadOnly();
        public void DeleteMovie(int id)
        {
            foreach(Movie movie in _movies) { 
                if(movie.Id_Movie == id)
                {
                    _movies.Remove(movie);
                }
            }
        }
     
        public void Dispose()
        {
            _movies.Clear();
        }

        public Movie GetMovie(int id)
        {
            return _movies
                .Where(m => m.Id_Movie == id)
                .FirstOrDefault();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return AllMovies;
        }

        public void InsertMovie(Movie movie)
        {
            _movies.Add(movie);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(Movie movie)
        {
            int index=0;
            foreach(Movie m in _movies)
            {
                if (m.Id_Movie == movie.Id_Movie)
                {
                    break;
                }
                index++;
            }
            _movies[index] = movie;
        }


    }
}
