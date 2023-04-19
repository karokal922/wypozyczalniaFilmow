using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Models;

namespace MovieRentalBLL.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetUsersWithRateCountSorted();
        public IEnumerable<User> GetUsersByNameSorted(string name);
    }
}
