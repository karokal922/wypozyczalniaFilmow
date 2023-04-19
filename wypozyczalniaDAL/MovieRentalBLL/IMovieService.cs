using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Models;

namespace MovieRentalBLL
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMoviesByCategory(Category category);
    }
}
