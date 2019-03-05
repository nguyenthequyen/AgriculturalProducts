using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public class ImagesClientServices : BaseService<Image>, IImagesClientServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImagesClientRepository _imagesClientRepository;
        public ImagesClientServices(IUnitOfWork unitOfWork, IImagesClientRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _imagesClientRepository = reponsitory;
            _unitOfWork = unitOfWork;

        }

        public async Task<Image> GetImageByProductId(string productId)
        {
            return await _imagesClientRepository.GetImageByProductId(productId);
        }
    }
}
