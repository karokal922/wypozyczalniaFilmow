using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Models;

namespace wypozyczalniaDAL.Interfaces
{
    public interface IRentRepository : IDisposable
    {
        IEnumerable<Rent> GetRents();
        Rent GetRent(int id);
        void InsertRent(Rent rent);
        void DeleteRent(int id);
        void UpdateRent(Rent rent);
        void Save();
    }
}
