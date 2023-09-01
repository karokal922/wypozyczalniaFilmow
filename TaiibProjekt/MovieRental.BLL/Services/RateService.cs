﻿using MovieRental.DAL.Interfaces;
using MovieRental.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Services
{
    public class RateService : IRateService
    {
        private readonly IUnitOfWork unitOfWork;

        public RateService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<MovieRatingResult> GetAverageRatePerMovie()
        {
            var rates = unitOfWork.RateRepository.GetRates();

            var queryResult = from rate in rates
                              group rate by rate.Movie into g
                              select new MovieRatingResult
                              {
                                  MovieId = g.Key.Id_Movie,
                                  MovieTitle = g.Key.Title,
                                  AverageRate = g.Average(r => r.RateValue)
                              };
            return queryResult.ToList();
        }

        public IEnumerable<UserRatingResult> GetAverageRatePerUser()
        {
            var rates = unitOfWork.RateRepository.GetRates();

            var queryResult = from rate in rates
                              group rate by rate.User into g
                              select new UserRatingResult
                              {
                                  UserId = g.Key.Id_User,
                                  UserName = g.Key.Name,
                                  AverageRate = g.Average(r => r.RateValue)
                              };
            return queryResult.ToList();
        }
    }
    public class MovieRatingResult
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public double AverageRate { get; set; }
    }
    public class UserRatingResult
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public double AverageRate { get; set; }
    }
}
