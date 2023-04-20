using Microsoft.EntityFrameworkCore;
using MovieRentalBLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;

namespace MovieRentalBLL.Services
{
    public class RentService : IRentService
    {
        private readonly IUnitOfWork unitOfWork;

        public RentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Rent> GetRentalsByUser(int userId)
        {
            var rentals = unitOfWork.RentRepository.GetRents();
            return (from rent in rentals
                    from Movie movie in rent.Movies
                    where rent.User_ID==userId
                    select rent).ToList();
        } 

        public List<Rent> GetRentalsByMovie(int movieId)
        {
            var rentals = unitOfWork.RentRepository.GetRents();
            var rentalsByMovie = new List<Rent>();

            foreach (var rental in rentals)
            {
                if (rental.Movies.Any(m => m.Id_Movie == movieId))
                {
                    rentalsByMovie.Add(rental);
                }
            }

            return rentalsByMovie;
        }

        public List<User> GetAllUsers()
        {
            return unitOfWork.UserRepository.GetUsers().ToList();
        }

        public List<Movie> GetAllMovies()
        {
            return unitOfWork.MovieRepository.GetMovies().ToList();
        }
    }
}
