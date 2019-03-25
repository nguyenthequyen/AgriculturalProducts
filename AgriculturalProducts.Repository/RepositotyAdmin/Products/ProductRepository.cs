using AgriculturalProducts.Models;
using AgriculturalProducts.Models.Common;
using System;
using System.Collections.Generic;
using System.IO;
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
        public List<object> GetAllProductAdim()
        {
            var product = _applicationContext.Products
                .OrderBy(x => x.CreatedDate)
                .Join(_applicationContext.StatusProducts, stt => stt.StatusProductId, st => st.Id, (stt, st) => new { stt, st })
                .Join(_applicationContext.Providers, sp => sp.stt.ProviderId, spp => spp.Id, (sp, spp) => new { sp, spp })
                .Join(_applicationContext.Units, us => us.sp.stt.UnitId, usp => usp.Id, (us, usp) => new { us, usp })
                .Join(_applicationContext.ProductTypes, pt => pt.us.sp.stt.ProductTypeId, ptp => ptp.Id, (pt, ptp) => new { pt, ptp })
                .Join(_applicationContext.Categeries, ct => ct.pt.us.sp.stt.CategoryId, ctp => ctp.Id, (ct, ctp) => new { ct, ctp })
                .Select(prd => new
                {
                    CreatedDate = prd.ct.pt.us.sp.stt.CreatedDate,
                    Name = prd.ct.pt.us.sp.stt.Name,
                    Id = prd.ct.pt.us.sp.stt.Id,
                    Code = prd.ct.pt.us.sp.stt.Code,
                    View = prd.ct.pt.us.sp.stt.View,
                    Cost = prd.ct.pt.us.sp.stt.Cost,
                    CostOld = prd.ct.pt.us.sp.stt.CostOld,
                    Mass = prd.ct.pt.us.sp.stt.Mass,
                    ShortDescription = prd.ct.pt.us.sp.stt.ShortDescription,
                    FullDescription = prd.ct.pt.us.sp.stt.FullDescription,
                    Quantity = prd.ct.pt.us.sp.stt.Quantity,
                    Sale = prd.ct.pt.us.sp.stt.Sale,
                    Category = prd.ctp.Name,
                    Provider = prd.ct.pt.us.spp.Name,
                    StatusProduct = prd.ct.pt.us.sp.st.Name,
                    Unit = prd.ct.pt.usp.Name,
                    Image = _applicationContext.Images.Where(p => p.ProductId == prd.ct.pt.us.sp.stt.Id).Select(img => new
                    {
                        Path = "data:image/png;base64, " + ConvertBase64.GetBase64StringForImage(img.Path)
                    }).ToList()
                }).ToList();
            List<object> products = new List<object>();
            foreach (var item in product)
            {
                products.Add(item);
            }
            return products;
        }

        public List<object> GetAllProductAdimSearchString(string name)
        {
            var product = _applicationContext.Products.Where(x => x.Name.Contains(name) || x.Code.Contains(name))
                .OrderBy(x => x.CreatedDate)
                .Join(_applicationContext.StatusProducts, stt => stt.StatusProductId, st => st.Id, (stt, st) => new { stt, st })
                .Join(_applicationContext.Providers, sp => sp.stt.ProviderId, spp => spp.Id, (sp, spp) => new { sp, spp })
                .Join(_applicationContext.Units, us => us.sp.stt.UnitId, usp => usp.Id, (us, usp) => new { us, usp })
                .Join(_applicationContext.ProductTypes, pt => pt.us.sp.stt.ProductTypeId, ptp => ptp.Id, (pt, ptp) => new { pt, ptp })
                .Join(_applicationContext.Categeries, ct => ct.pt.us.sp.stt.CategoryId, ctp => ctp.Id, (ct, ctp) => new { ct, ctp })
                .Select(prd => new
                {
                    CreatedDate = prd.ct.pt.us.sp.stt.CreatedDate,
                    Name = prd.ct.pt.us.sp.stt.Name,
                    Id = prd.ct.pt.us.sp.stt.Id,
                    Code = prd.ct.pt.us.sp.stt.Code,
                    View = prd.ct.pt.us.sp.stt.View,
                    Cost = prd.ct.pt.us.sp.stt.Cost,
                    CostOld = prd.ct.pt.us.sp.stt.CostOld,
                    Mass = prd.ct.pt.us.sp.stt.Mass,
                    ShortDescription = prd.ct.pt.us.sp.stt.ShortDescription,
                    FullDescription = prd.ct.pt.us.sp.stt.FullDescription,
                    Quantity = prd.ct.pt.us.sp.stt.Quantity,
                    Sale = prd.ct.pt.us.sp.stt.Sale,
                    Category = prd.ctp.Name,
                    Provider = prd.ct.pt.us.spp.Name,
                    StatusProduct = prd.ct.pt.us.sp.st.Name,
                    Unit = prd.ct.pt.usp.Name,
                    Image = _applicationContext.Images.Where(p => p.ProductId == prd.ct.pt.us.sp.stt.Id).Select(img => new
                    {
                        Path = "data:image/png;base64, " + ConvertBase64.GetBase64StringForImage(img.Path)
                    }).ToList()
                }).ToList();
            List<object> products = new List<object>();
            foreach (var item in product)
            {
                products.Add(item);
            }
            return products;
        }

        public void GetAllProductPaging()
        {
            throw new NotImplementedException();
        }

        public void GetTopNewPoduct()
        {
            _applicationContext.Products
               .Join(_applicationContext.Images, p => p.Id, img => img.ProductId, (p, img) => new { p, img })
               .Select(prd => new
               {
                   ProductName = prd.p.Name,
                   Imgage = prd.img.Path.ToList()
               }).ToList();
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
