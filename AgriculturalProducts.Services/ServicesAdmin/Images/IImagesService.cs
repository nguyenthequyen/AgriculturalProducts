using AgriculturalProducts.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IImagesService : IBaseService<Image>
    {
        void InsertImage(List<IFormFile> files, string productId);
        void DeleteImage(Image image);
        IEnumerable<Image> FindImageById(Guid id);
        void InsertImageExcelt(Image image);
    }
}
