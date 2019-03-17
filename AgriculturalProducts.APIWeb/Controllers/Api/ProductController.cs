using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.APIWeb.Models;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Serilog;
using Action = AgriculturalProducts.Models.Action;

namespace AgriculturalProducts.APIWeb.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductClientService _productService;
        private readonly IImagesClientServices _imagesClientServices;
        private readonly IStatisticsService _statisticsService;
        private readonly ILogger<ProductController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationContext _applicationContext;
        public ProductController(
            IProductClientService productService,
            IImagesClientServices imagesClientServices,
            IStatisticsService statisticsService,
        ApplicationContext applicationContext,
        IHostingEnvironment hostingEnvironment,
            ILogger<ProductController> logger)
        {
            _applicationContext = applicationContext;
            _logger = logger;
            _productService = productService;
            _imagesClientServices = imagesClientServices;
            _hostingEnvironment = hostingEnvironment;
            _statisticsService = statisticsService;
        }
        /// <summary>
        /// Danh sách các sản phẩm mới nhất
        /// </summary>
        /// <returns></returns>
        /// Created by: NTQuyen 05/03/2019
        [HttpPost]
        [Route("list-new-product")]
        public async Task<IActionResult> GetListNewProducts()
        {
            try
            {

                var data = _productService.GetTopNewPoduct();
                Statistics statistics = new Statistics()
                {
                    Action = (int)Action.Visitor,
                    ActionName = "Truy cập vào trang web",
                    CreatedDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    ModifyDate = DateTime.Now
                };
                var sesion = HttpContext.Session.GetString("visitor");
                if (sesion == null)
                {
                    HttpContext.Session.SetString("visitor", "visitor");
                    _statisticsService.InsertStatistics(statistics);
                }
                return Ok(new Result() { Code = 200, Data = data, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lõi lấy sản phẩm mới nhất: " + ex);
                return Ok(new Result() { Code = 200, Data = null, Error = "Lỗi lấy danh sách sản phẩm mới nhất" });
            }
        }
        [HttpPost]
        [Route("list-top-discount-product")]
        public async Task<IActionResult> GetListDiscountProduct()
        {
            try
            {
                var data = _productService.GetListDiscountProducts();
                return Ok(new Result() { Code = 200, Data = data, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lõi lấy sản phẩm giảm giá nhiều nhất: " + ex);
                return Ok(new Result() { Code = 200, Data = null, Error = "Lỗi lấy danh sách sản phẩm mới nhất" });
            }
        }
        [HttpPost]
        [Route("get-product-details")]
        public async Task<IActionResult> GetProductDetails(ProductId id)
        {
            try
            {
                var data = _productService.GetProductDetails(id.Id);
                return Ok(new Result() { Code = 200, Data = data, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy chi tiết sản phẩm: " + ex);
                return Ok(new Result() { Code = 200, Data = null, Error = "Lỗi lấy danh sách sản phẩm mới nhất" });
            }
        }
        [HttpPost]
        [Route("update-product")]
        public async Task<IActionResult> UpdateProvider(Product provider)
        {
            _productService.Update(provider);
            return Ok();
        }
        [HttpPost]
        [Route("get-image-display-web")]
        public async Task<IActionResult> GetImageFile([FromBody]ProductId id)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var folderName = @"E:\AgriculturalProducts\Upload" + @"\" + id.Id;
            List<ImageResult> imageResults = new List<ImageResult>();
            foreach (var files in Directory.GetFiles(folderName))
            {
                ImageResult imageResult = new ImageResult();
                FileInfo info = new FileInfo(files);
                var fileName = Path.GetFileName(info.FullName);
                imageResult.Path = folderName + "\\" + fileName;
                imageResults.Add(imageResult);
            }
            return Ok(new Result() { Data = imageResults, Code = 200, Error = null });
        }
        [HttpPost]
        [Route("details-products")]
        public async Task<IActionResult> GetDetailsProduct([FromBody]ProductId id)
        {
            _productService.GetProductDetails(id.Id);
            return Ok();
        }
        [HttpPost]
        [Route("delete-product")]
        public async Task<IActionResult> DeleteProvider(Product provider)
        {
            _productService.Delete(provider);
            return Ok();
        }

        [HttpPost]
        [Route("get-product")]
        public async Task<IActionResult> GetAllProvider()
        {
            var provider = _productService.GetAllRecords();
            return Ok();
        }
        [HttpPost]
        [Route("find-product")]
        public async Task<IActionResult> FindProductById(Guid id)
        {
            await _productService.GetFirstOrDefault(id);
            return Ok();
        }
        [Route("find-product-by-name")]
        [HttpPost]
        public async Task<IActionResult> FindProductByName([FromBody]ProductName name)
        {
            try
            {
                var data = _productService.FindProductByName(name.Name);
                return Ok(new Result() { Code = 200, Data = data, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi tìm kiếm sản phẩm theo tên: " + ex);
                return Ok(new Result() { Code = 200, Data = null, Error = "Lỗi tìm kiếm sản phẩm" });
            }
        }
        [Route("get-carts")]
        [Authorize(Roles = "Users")]
        [HttpPost]
        public async Task<IActionResult> CartDetailsFromUser()
        {
            return Ok();
        }
    }
}