using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Interfaces
{
    public interface IRentService
    {
        public List<Rent> GetRentalsByUser(int userId);
        public List<Rent> GetRentalsByMovie(int movieId);
        public List<User> GetAllUsers();
        public List<Movie> GetAllMovies();
    }
}
