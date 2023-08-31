using MovieRental.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Services
{
    public class RateService
    {
        private readonly IUnitOfWork unitOfWork;

        public RateService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<object> GetAverageRatePerMovie()
        {
            var rates = unitOfWork.RateRepository.GetRates();

            var queryResult = from rate in rates
                              group rate by rate.Movie into g
                              select new
                              {
                                  MovieId = g.Key.Id_Movie,
                                  MovieTitle = g.Key.Title,
                                  AverageRate = g.Average(r => r.RateValue)
                              };
            return queryResult.ToList();
        }

        public IEnumerable<object> GetAverageRatePerUser()
        {
            var rates = unitOfWork.RateRepository.GetRates();

            var queryResult = from rate in rates
                              group rate by rate.User into g
                              select new
                              {
                                  UserId = g.Key.Id_User,
                                  UserName = g.Key.Name,
                                  AverageRate = g.Average(r => r.RateValue)
                              };
            return queryResult.ToList();
        }
    }
}
