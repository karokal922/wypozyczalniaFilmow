using MovieRentalBLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Repositories;

namespace MovieRentalBLL.Services
{
    public class RateService : IRateService
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
                              group rate by rate.Movie_ID into g
                              select new
                              {
                                  MovieId = g.Key,
                                  AverageRate = g.Average(r => r._Rate)
                              };
            return queryResult.ToList();
        }

        public IEnumerable<object> GetAverageRatePerUser()
        {
            var rates = unitOfWork.RateRepository.GetRates();

            var queryResult = from rate in rates
                              group rate by rate.User_ID into g
                              select new
                              {
                                  UserId = g.Key,
                                  AverageRate = g.Average(r => r._Rate)
                              };
            return queryResult.ToList();
        }
    }
}
