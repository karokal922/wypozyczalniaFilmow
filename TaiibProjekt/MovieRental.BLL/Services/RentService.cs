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
            return rentals;
        }

        public List<Rent> GetRentalsByMovie(int movieId)
        {
            var rentals = unitOfWork.RentRepository.GetRents().Where(r => r.Movies.Any(m => m.Id_Movie == movieId)).ToList();
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
        public int? CreateRent(Rent rentModel) 
        {
            if(rentModel.Movies.Count() <= 0 || rentModel.User == null)
            {
                return null;
            }
            unitOfWork.RentRepository.InsertRent(rentModel);
            unitOfWork.RentRepository.Save();
            return rentModel.Id_Rent;
        }
    }
}
