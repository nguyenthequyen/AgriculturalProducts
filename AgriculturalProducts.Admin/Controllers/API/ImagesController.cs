using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturalProducts.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ImagesController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ImagesController(IHttpContextAccessor httpContextAccessor, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        [Route("upload-images")]
        public async Task<IActionResult> UploadImages(List<IFormFile> files)
        {
            var productId = _httpContextAccessor.HttpContext.Request.Headers["ProductId"].ToString();
            if (files != null && files.Count > 0)
            {
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(folderName+"\\"+webRootPath, productId);
                if (!Directory.Exists(productId))
                {
                    Directory.CreateDirectory(newPath);
                }
                foreach (IFormFile item in files)
                {
                    if (item.Length > 0)
                    {
                        string fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                        string fullPath = Path.Combine(newPath, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            item.CopyTo(stream);
                        }
                    }
                }
                return this.Content("Success");
            }
            return this.Content("Fail");
        }
    }
}