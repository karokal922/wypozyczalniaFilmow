using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Models;

namespace wypozyczalniaDAL.Interfaces
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
        void InsertCategory(Category category);
        void DeleteCategory(int id);
        void UpdateCategory(Category category);
        void Save();
        
    }
}
