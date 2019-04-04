using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class MarketRepository : BaseRepository<Product>, IMarketRepository
    {
        private readonly ApplicationContext _applicationContext;
        public MarketRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }
    }
}
