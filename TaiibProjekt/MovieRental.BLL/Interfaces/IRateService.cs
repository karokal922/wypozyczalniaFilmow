using MovieRental.BLL.Services;
using MovieRental.DAL.Models;
using MovieRental.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Interfaces
{
    public interface IRateService
    {
        public IEnumerable<MovieRatingResult> GetAverageRatePerMovie();
        public IEnumerable<UserRatingResult> GetAverageRatePerUser();
        public IEnumerable<User> GetAllUsers();
        public IEnumerable<Movie> GetAllMovies();
        public IEnumerable<Rate> GetAllRates();
        public int? CreateRate(Rate rateModel);
    }
}
