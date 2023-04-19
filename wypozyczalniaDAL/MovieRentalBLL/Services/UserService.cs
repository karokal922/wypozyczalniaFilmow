using MovieRentalBLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;

namespace MovieRentalBLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<User> GetUsersByNameSorted(string name)
        {
            var users = unitOfWork.UserRepository.GetUsers();

            return (from user in users
                    where user.Name == name
                    orderby user.Surname ascending
                    select user).ToList();
        }

        public IEnumerable<object> GetUsersWithRateCountSorted()
        {
            var users = unitOfWork.UserRepository.GetUsers();

            var queryResult = from user in users
                              let rateCount = user.Rates?.Count() ?? 0
                              orderby rateCount descending
                              select new
                              {
                                  Name = user.Name,
                                  Surname = user.Surname,
                                  RateCount = rateCount
                              };
            return queryResult.ToList();
        }
    }
}
