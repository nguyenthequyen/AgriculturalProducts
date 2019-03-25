using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void DeleteImage(Image image)
        {
            Delete(image);
        }

        public IEnumerable<Image> FindImageById(Guid id)
        {
            return _applicationContext.Images.Where(x=>x.ProductId == id).ToList();
        }

        public void InsertImage(Image image)
        {
            _applicationContext.Add(image);
        }
    }
}
