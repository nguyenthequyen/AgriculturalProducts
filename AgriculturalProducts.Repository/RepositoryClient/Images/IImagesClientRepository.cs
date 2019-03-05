using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public interface IImagesClientRepository : IBaseRepository<Image>
    {
        Task<Image> GetImageByProductId(string productId);
    }
}
