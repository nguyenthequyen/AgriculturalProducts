using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class ImagesService : BaseService<Image>, IImagesService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImagesRepository _reponsitory;
        public ImagesService(
            IUnitOfWork unitOfWork,
            IImagesRepository reponsitory,
            IHostingEnvironment hostingEnvironment) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
            _hostingEnvironment = hostingEnvironment;
        }

        public void InsertImage(List<IFormFile> files, string productId)
        {
            if (files != null && files.Count > 0)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(@"/home/ntquyen/Desktop/Upload", productId);
                if (!Directory.Exists(productId))
                {
                    Directory.CreateDirectory(newPath);
                }
                foreach (IFormFile item in files)
                {
                    if (item.Length > 0)
                    {
                        string fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                        string reversed = new String(fileName.ToCharArray().Reverse().ToArray());
                        var extension = reversed.Split(".");
                        char[] fileNameArray = extension[0].ToCharArray();
                        Array.Reverse(fileNameArray);
                        var name = Guid.NewGuid();
                        fileName = name + "." + String.Join("", fileNameArray); ;
                        string fullPath = Path.Combine(newPath, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            item.CopyTo(stream);
                        }
                        Image image = new Image();
                        image.Id = Guid.NewGuid();
                        image.ModifyDate = DateTime.Now;
                        image.CreatedDate = DateTime.Now;
                        image.Path = fullPath;
                        image.Name = 0.ToString();
                        image.ProductId = Guid.Parse(productId);
                        _reponsitory.InsertImage(image);
                    }
                }
                _unitOfWork.Commit();
            }
        }
    }
}
