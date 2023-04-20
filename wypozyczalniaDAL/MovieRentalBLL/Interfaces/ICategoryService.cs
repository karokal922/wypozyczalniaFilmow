using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalBLL.Interfaces
{
    public interface ICategoryService
    {
        Dictionary<string, List<string>> GetMovieTitlesByCategories(params string[] categories);
        IEnumerable<object> GetCategoriesWithMovieCount();
    }
}
