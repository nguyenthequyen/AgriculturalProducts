using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface IImagesClientServices:IBlogsService<Image>
    {
        Task<Image> GetImageByProductId(string productId);
    }
}
