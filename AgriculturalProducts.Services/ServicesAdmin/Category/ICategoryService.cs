using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
        void InsertCategory(List<Category> category);
        void UpdateCategory(List<Category> category);
        IEnumerable<Category> GetAllCategory();
        void DeleteCategory(List<Category> category);
        Task<Category> FindCategoryById(Guid id);
        int CategoryStatistics();
    }
}
