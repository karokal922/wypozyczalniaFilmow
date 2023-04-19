using MovieRentalBLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Interfaces;

namespace MovieRentalBLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<object> GetCategoriesWithMovieCount()
        {
            var categories = unitOfWork.CategoryRepository.GetCategories();

            return (from category in categories
                   let movieCount = category.Movies.Count()
                   select new
                   {
                       CategoryName = category.CategoryName,
                       MovieCount = movieCount
                   }).ToList();
        }
        public Dictionary<string, List<string>> GetMovieTitlesByCategories(params string[] categories)
        {
            var movies = unitOfWork.MovieRepository.GetMovies();

            return (from movie in movies
                    from category in movie.Categories
                    where categories.Contains(category.CategoryName.ToLower())
                    group movie.Title by category.CategoryName into categoryGroup
                    select new
                    {
                        Category = categoryGroup.Key,
                        Movies = categoryGroup.ToList()
                    }).ToDictionary(x => x.Category, x => x.Movies);
        }
    }
}
