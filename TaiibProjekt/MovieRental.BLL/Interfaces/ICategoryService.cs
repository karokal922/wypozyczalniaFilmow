using MovieRental.BLL.Services;
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
        IEnumerable<CategoryMovieCountResult> GetCategoriesWithMovieCount();
    }
}
