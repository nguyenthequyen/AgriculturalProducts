using AgriculturalProducts.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IImagesService : IBlogsService<Image>
    {
        void InsertImage(List<IFormFile> files, string productId);
    }
}
