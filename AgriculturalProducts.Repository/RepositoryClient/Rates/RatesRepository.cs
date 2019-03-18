using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class RatesRepository : BaseRepository<Rate>, IRatesRepository
    {
        private readonly ApplicationContext _applicationContext;
        public RatesRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void CreatedRate(Rate rate)
        {
            Add(rate);
        }
        public List<object> GetAllRates(Guid id)
        {
            var rate = _applicationContext.Rates.Where(x => x.ProductId == id).GroupBy(x => x.Quantity).Select(
                r => new
                {
                    label = r.Key,
                    y = r.Distinct().Count()
                }
                ).ToList();
            List<object> rates = new List<object>();
            foreach (var item in rate)
            {
                rates.Add(item);
            }
            return rates;
        }
    }
}
