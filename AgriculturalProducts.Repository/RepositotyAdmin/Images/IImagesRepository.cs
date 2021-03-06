﻿using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IImagesRepository : IBaseRepository<Image>
    {
        void InsertImage(Image image);
        void DeleteImage(Image image);
        IEnumerable<Image> FindImageById(Guid id);
    }
}
