using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class ProductClientRepository : BaseRepository<Product>, IProductClientRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ProductClientRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public List<object> GetTopNewPoduct()
        {
            var product = _applicationContext.Products.Select(x => new
            {
                Name = x.Name,
                Id = x.Id,
                Cost = x.Cost,
                Code = x.Code,
                Sale = x.Sale,
                Image = _applicationContext.Images.Join(_applicationContext.Products, p => p.ProductId, pd => pd.Id, (p, pd) => new { p, pd }).Select(pt => new
                {
                    Path = pt.p.Path
                })
            }).ToList();
            List<object> products = new List<object>();
            foreach (var item in product)
            {
                products.Add(item);
            }
            return products;
        }
    }
}
