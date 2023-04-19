using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Models;

namespace MovieRentalBLL.Interfaces
{
    public interface IRentService
    {
        public List<Rent> GetRentalsByUser(int userId);
        public List<Rent> GetRentalsByMovie(int movieId);

    }
}
