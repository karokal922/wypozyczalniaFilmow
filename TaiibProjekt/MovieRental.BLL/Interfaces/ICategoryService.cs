using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Interfaces
{
    public interface ICategoryService
    {
        Dictionary<string, List<string>> GetMovieTitlesByCategories(params string[] categories);
        IEnumerable<object> GetCategoriesWithMovieCount();
    }
}
