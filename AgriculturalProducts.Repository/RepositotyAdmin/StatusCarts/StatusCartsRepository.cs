using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class StatusCartsRepository : BaseRepository<StatusCart>, IStatusCartsRepository
    {
        private readonly ApplicationContext _applicationContext;
        public StatusCartsRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void InsertStatusCarts(StatusCart statusCart)
        {
            Add(statusCart);
        }
    }
}
