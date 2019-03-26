using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //[Authorize(Roles = "Owner,Admin")]
    public class ImagesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ImagesController> _logger;
        private readonly IImagesService _imagesService;
        public ImagesController(
            IHttpContextAccessor httpContextAccessor,
            ILogger<ImagesController> logger,
            IImagesService imagesService)
        {
            _httpContextAccessor = httpContextAccessor;
            _imagesService = imagesService;
            _logger = logger;
        }
        [HttpPost]
        [Route("upload-images")]
        public async Task<IActionResult> UploadImages(List<IFormFile> files)
        {
            try
            {
                var productId = _httpContextAccessor.HttpContext.Request.Headers["ProductId"].ToString();
                _imagesService.InsertImage(files, productId);
                return Ok(new Result() { Code = 200, Data = "Thêm ảnh thành công", Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi upload hình ảnh: " + ex);
                return Ok(new Result() { Code = ex.HResult, Data = null, Error = "Thêm ảnh thất bại" });
            }
        }
    }
}