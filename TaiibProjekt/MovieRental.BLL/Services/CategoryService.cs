using MovieRental.DAL.Interfaces;
using MovieRental.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRental.DAL.Models;

namespace MovieRental.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<CategoryMovieCountResult> GetCategoriesWithMovieCount()
        {
            var categories = unitOfWork.CategoryRepository.GetCategories();

            return (from category in categories
                    let movieCount = category.Movies.Count()
                    select new CategoryMovieCountResult
                    {
                        CategoryName = category.CategoryName,
                        MovieCount = movieCount
                    }).ToList();
        }
    }
    public class CategoryMovieCountResult
    {
        public string CategoryName { get; set; }
        public int MovieCount { get; set; }
    }
}
