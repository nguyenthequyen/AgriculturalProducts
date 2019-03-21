using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface ICategoriesClientService:IBaseService<Category>
    {
        IEnumerable<Category> GetCategories();
        List<object> GetProductByCategory(Guid name);
    }
}
