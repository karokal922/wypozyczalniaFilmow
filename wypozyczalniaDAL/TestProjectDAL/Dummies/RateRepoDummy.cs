﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;

namespace TestProjectDAL.Dummies
{
    public class RateRepoDummy : IRateRepository
    {
        public void DeleteRate(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Rate GetRate(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rate> GetRates()
        {
            throw new NotImplementedException();
        }

        public void InsertRate(Rate rate)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateRate(Rate rate)
        {
            throw new NotImplementedException();
        }
    }
}
