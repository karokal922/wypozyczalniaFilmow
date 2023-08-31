using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Services
{
    public class UserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<User> GetUsersByNameSorted(string name)
        {
            var users = unitOfWork.UserRepository.GetUsers().Where(u=>u.Name==name).OrderBy(u=>u.Surname).ToList();

            //return (from user in users
            //        where user.Name == name
            //        orderby user.Surname ascending
            //        select user).ToList();
            return users;
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
