using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ProductRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void InsertProduct(Product product)
        {
             _applicationContext.Products.Add(product);
        }
    }
}
