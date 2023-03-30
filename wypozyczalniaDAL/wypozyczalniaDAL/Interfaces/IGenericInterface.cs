using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Models;

namespace wypozyczalniaDAL.Interfaces
{
    public interface IGenericInterface<T> : IDisposable
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Insert(T value);
        void Delete(int id);
        void Update(T value);
        void Save();
    }
}
