﻿using AgriculturalProducts.Models;
using AgriculturalProducts.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Path = "data:image/png;base64, " + ConvertBase64.GetBase64StringForImage(img.Path)
                }).ToList()
            }).OrderBy(x => x.Created).Take(10).ToList();
            List<object> products = new List<object>();
            foreach (var item in product)
            {
                products.Add(item);
            }
            return products;
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
                    Path = "data:image/png;base64, " + ConvertBase64.GetBase64StringForImage(img.Path)
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
                    Path = "data:image/png;base64, " + ConvertBase64.GetBase64StringForImage(img.Path)
                }).ToList()
            }).Where(x => x.Id == id);
            List<object> products = new List<object>();
            foreach (var item in product)
            {
                products.Add(item);
            }
            return products;
        }

        public List<object> FindProductByName(string name)
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
                    Path = "data:image/png;base64, " + ConvertBase64.GetBase64StringForImage(img.Path)
                }).ToList()
            }).Where(x => x.Name.StartsWith(name)).ToList();
            List<object> products = new List<object>();
            foreach (var item in product)
            {
                products.Add(item);
            }
            return products;
        }

        public void UpdateProduct(Guid id, int quantity)
        {
            Product product = _applicationContext.Products.Single(x => x.Id == id);
            product.Quantity = quantity;
        }

    }
}
