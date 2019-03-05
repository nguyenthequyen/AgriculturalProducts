using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IImagesService _imagesService; 
        public ImagesController(
            IHttpContextAccessor httpContextAccessor, 
            IImagesService imagesService)
        {
            _httpContextAccessor = httpContextAccessor;
            _imagesService = imagesService;
        }
        [HttpPost]
        [Route("upload-images")]
        public async Task<IActionResult> UploadImages(List<IFormFile> files)
        {
            try
            {
                var productId = _httpContextAccessor.HttpContext.Request.Headers["ProductId"].ToString();
                _imagesService.InsertImage(files, productId);
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }
    }
}