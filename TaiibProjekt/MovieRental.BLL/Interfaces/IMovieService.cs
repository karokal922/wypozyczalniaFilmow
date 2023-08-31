using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMoviesByCategory(int category_id);
        IEnumerable<Movie> SortMoviesByRatingsInGivenYear(int year);
        IEnumerable<Category> GetAllCategories();
    }
}
