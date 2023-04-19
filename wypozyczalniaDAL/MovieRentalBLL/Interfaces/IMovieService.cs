using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalBLL.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMoviesByCategory(Category category);
        IEnumerable<Movie> SortMoviesByRatingsInGivenYear(int year);
    }
}
