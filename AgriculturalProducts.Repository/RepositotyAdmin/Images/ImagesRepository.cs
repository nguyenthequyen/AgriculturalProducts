using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class ImagesRepository : BaseRepository<Image>, IImagesRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ImagesRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void InsertImage(Image image)
        {
            _applicationContext.Add(image);
        }
    }
}
