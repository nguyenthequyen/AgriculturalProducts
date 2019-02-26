using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        void InsertCategory(Category Category);
        void UpdateCategory(Category Category);
        IEnumerable<Category> GetAllCategory();
        void DeleteCategory(Category Category);
        Task<Category> FindCategoryById(Guid id);
        int CategoryStatistics();
    }
}
