using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ProductRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void DeleteProduct(Product provider)
        {
            Delete(provider);
        }

        public async Task<Product> FindProductById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return GetAllRecords();
        }

        public void GetAllProductPaging()
        {
            //var categorizedProducts = _applicationContext.Products
            // .Join(_applicationContext.Categeries, p => p.CategoryId, pc => pc.Id, (p, pc) => new { p, pc })
            // .Join(_applicationContext.Units, u => u.p.UnitId, c => c.Id, (u, c) => new { u, c })
            // .Join(_applicationContext.Providers, pv => pv.u.p.ProviderId, p => p.Id, (pv, p) => new { pv, p })
            // .Join(_applicationContext.ProductTypes, pt => pt.pv.u.p.ProductTypeId, pts => pts.Id, (pt, pts) => new { pt, pts })
            // .Join(_applicationContext.Images, img => img.imdt.ImageId, im => im.Id, (img, im) => new { img, im })
            // .Select(m => new
            // {
            //     ProductName = m.img.imd.pt.pv.u.p.Name,
            //     ProductCode = m.img.imd.pt.pv.u.p.Code,
            //     ProductCost = m.img.imd.pt.pv.u.p.Cost,
            //     ProductQuantity = m.img.imd.pt.pv.u.p.Quantity,
            //     ProductFullDescription = m.img.imd.pt.pv.u.p.FullDescription,
            //     ProductView = m.img.imd.pt.pv.u.p.View,
            //     ProductStatus = m.img.imd.pt.pv.u.p.Status,
            //     ProductMass = m.img.imd.pt.pv.u.p.Mass,
            //     ProductShortDescription = m.img.imd.pt.pv.u.p.ShortDescription,
            //     ProductSale = m.img.imd.pt.pv.u.p.Sale,
            //     ProductTypesName = m.img.imd.pts.Name,
            //     ProvidersName = m.img.imd.pt.p.Name,
            //     CategeriesName = m.img.imd.pt.p.Name,
            //     UnitName = m.img.imd.pt.pv.c.Name,
            //     Path = m.im.Path
            // }).ToList();
        }

        public void InsertProduct(Product product)
        {
            Add(product);
        }

        public int ProductStatistics()
        {
            return _applicationContext.Products.Count();
        }

        public void UpdateProduct(Product provider)
        {
            Update(provider);
        }
    }
}
