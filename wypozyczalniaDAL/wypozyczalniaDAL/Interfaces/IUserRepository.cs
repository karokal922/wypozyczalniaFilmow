using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Models;

namespace wypozyczalniaDAL.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void InsertUser(User user);
        void DeleteUser(int id);
        void UpdateUser(User user);
        void Save();
    }
}
