using AgriculturalProducts.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class CartsMapperRepository : BaseRepository<ProductCart>, ICartsMapperRepository
    {
        private readonly ApplicationContext _applicationContext;
        public CartsMapperRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public ProductCart GetProductCart(Guid id)
        {
            ProductCart products = new ProductCart();
            var data = _applicationContext.Products.Where(x => x.Id == id).Select(x => new
            {
                Name = x.Name,
                Id = x.Id,
                Cost = x.Cost,
                Image = _applicationContext.Images.Where(p => p.ProductId == x.Id).Select(img => new
                {
                    Path = "data:image/png;base64, " + ConvertBase64.GetBase64StringForImage(img.Path)
                })
            });
            foreach (var item in data)
            {
                products.Id = item.Id;
                products.Name = item.Name;
                products.Cost = item.Cost;
                foreach (var image in item.Image)
                {
                    products.Path = image.Path;
                }
            }
            return products;
        }
    }
}
