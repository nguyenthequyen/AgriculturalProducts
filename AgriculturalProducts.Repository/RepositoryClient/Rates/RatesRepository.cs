using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
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
    }
}
