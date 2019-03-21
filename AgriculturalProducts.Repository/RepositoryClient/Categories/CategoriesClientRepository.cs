using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class CategoriesClientRepository : BaseRepository<Category>, ICategoriesClientRepository
    {
        private readonly ApplicationContext _applicationContext;
        public CategoriesClientRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<Category> GetCategories()
        {
            return GetAllRecords();
        }

        public List<object> GetProductByCategory(Guid name)
        {
            var product = _applicationContext.Products
                 .Join(_applicationContext.StatusProducts, stt => stt.StatusProductId, st => st.Id, (stt, st) => new { stt, st })
                 .Join(_applicationContext.Providers, sp => sp.stt.ProviderId, spp => spp.Id, (sp, spp) => new { sp, spp })
                 .Join(_applicationContext.Units, us => us.sp.stt.UnitId, usp => usp.Id, (us, usp) => new { us, usp })
                 .Join(_applicationContext.ProductTypes, pt => pt.us.sp.stt.ProductTypeId, ptp => ptp.Id, (pt, ptp) => new { pt, ptp })
                 .Join(_applicationContext.Categeries, ct => ct.pt.us.sp.stt.CategoryId, ctp => ctp.Id, (ct, ctp) => new { ct, ctp })
                 .Where(x => x.ctp.Id == name)
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
                         Path = "data:image/png;base64, " + GetBase64StringForImage(img.Path)
                     }).ToList()
                 }).ToList();
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
    }
}
