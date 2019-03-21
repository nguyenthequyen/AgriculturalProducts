using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface ICategoriesClientRepository:IBaseRepository<Category>
    {
        IEnumerable<Category> GetCategories();
        List<object> GetProductByCategory(Guid name);
    }
}
