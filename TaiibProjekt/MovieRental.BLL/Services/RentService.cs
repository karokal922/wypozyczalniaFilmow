using MovieRental.DAL.Interfaces;
using MovieRental.BLL.Interfaces;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Services
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
            var rentals = unitOfWork.RentRepository.GetRents().Where(r => r.UserId == userId).ToList();
            //return (from rent in rentals
            //        from Movie movie in rent.Movies
            //        where rent.UserId == userId
            //        select rent).ToList();
            return rentals;
        }

        public List<Rent> GetRentalsByMovie(int movieId)
        {
            var rentals = unitOfWork.RentRepository.GetRents().Where(r => r.Movies.Any(m => m.Id_Movie == movieId)).ToList();
            //var rentalsByMovie = new List<Rent>();
            //foreach (var rental in rentals)
            //{
            //    if (rental.Movies.Any(m => m.Id_Movie == movieId))
            //    {
            //        rentalsByMovie.Add(rental);
            //    }
            //}

            return rentals;
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
