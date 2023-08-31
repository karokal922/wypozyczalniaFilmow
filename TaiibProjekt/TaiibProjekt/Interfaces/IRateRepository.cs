using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Interfaces
{
    public interface IRateRepository : IDisposable
    {
        IEnumerable<Rate> GetRates();
        Rate GetRate(int id);
        void InsertRate(Rate rate);
        void DeleteRate(int id);
        void UpdateRate(Rate rate);
        void Save();
    }
}
