using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Tests.Dummies
{
    public class CategoryRepoDummy : ICategoryRepository
    {
        void ICategoryRepository.DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Category> ICategoryRepository.GetCategories()
        {
            throw new NotImplementedException();
        }

        Category ICategoryRepository.GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        void ICategoryRepository.InsertCategory(Category category)
        {
            throw new NotImplementedException();
        }

        void ICategoryRepository.Save()
        {
            throw new NotImplementedException();
        }

        void ICategoryRepository.UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
