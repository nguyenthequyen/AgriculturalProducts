using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public class ImagesClientRepository : BaseRepository<Image>, IImagesClientRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ImagesClientRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Image> GetImageByProductId(string productId)
        {
            return await GetFirstOrDefault(Guid.Parse(productId));
        }
    }
}
