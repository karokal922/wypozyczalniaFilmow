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
        IEnumerable<Movie> SortMoviesByAvgRatingsInGivenYear(int year);
        IEnumerable<Category> GetAllCategories();
    }
}
