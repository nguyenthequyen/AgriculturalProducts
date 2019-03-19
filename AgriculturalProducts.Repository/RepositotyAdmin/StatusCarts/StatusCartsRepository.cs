using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public StatusCart GetStatusCartsClient()
        {
            return _applicationContext.StatusCarts.SingleOrDefault(x => x.Name == "Chờ xử lý");
        }

        public void InsertStatusCarts(StatusCart statusCart)
        {
            Add(statusCart);
        }
    }
}
