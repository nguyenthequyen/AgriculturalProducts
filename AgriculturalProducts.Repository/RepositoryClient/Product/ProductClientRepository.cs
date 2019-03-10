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
                Created = x.CreatedDate,
                Image = _applicationContext.Images.Where(p => p.ProductId == x.Id).Select(img => new
                {
                    Path = "data:image/png;base64, " + GetBase64StringForImage(img.Path)
                }).ToList()
            }).OrderBy(x => x.Created).Take(10).ToList();
            List<object> products = new List<object>();
            foreach (var item in product)
            {
                products.Add(item);
            }
            return products;
        }
        private static string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

        public List<object> GetListDiscountProducts()
        {
            var product = _applicationContext.Products.Select(x => new
            {
                Name = x.Name,
                Id = x.Id,
                Cost = x.Cost,
                Code = x.Code,
                Sale = x.Sale,
                Created = x.CreatedDate,
                Image = _applicationContext.Images.Where(p => p.ProductId == x.Id).Select(img => new
                {
                    Path = "data:image/png;base64, " + GetBase64StringForImage(img.Path)
                }).ToList()
            }).OrderBy(x => x.Sale).Take(8).ToList();
            List<object> products = new List<object>();
            foreach (var item in product)
            {
                products.Add(item);
            }
            return products;
        }

        public List<object> GetProductDetails(Guid id)
        {
            var product = _applicationContext.Products.Select(x => new
            {
                Name = x.Name,
                Id = x.Id,
                Cost = x.Cost,
                Code = x.Code,
                Sale = x.Sale,
                ShortDescription = x.ShortDescription,
                FullDescription = x.FullDescription,
                Created = x.CreatedDate,
                Image = _applicationContext.Images.Where(p => p.ProductId == x.Id).Select(img => new
                {
                    Path = "data:image/png;base64, " + GetBase64StringForImage(img.Path)
                }).ToList()
            }).Where(x => x.Id == id).ToList();
            List<object> products = new List<object>();
            foreach (var item in product)
            {
                products.Add(item);
            }
            return products;
        }
    }
}
