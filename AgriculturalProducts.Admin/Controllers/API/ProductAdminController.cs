using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.Web.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAdminController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger _logger;
        public ProductAdminController(
            IProductService productService,
            ILogger<ProductAdminController> logger)
        {
            _logger = logger;
            _productService = productService;
        }
        [HttpPost]
        [Route("insert-product")]
        public async Task<IActionResult> InsertProduct(List<Product> product)
        {
            try
            {
                _productService.InsertProduct(product);
                return Ok(new Result() { Data = "Thêm sản phẩm thành công", Code = 200, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi thêm sản phẩm: " + ex);
                return Ok(new Result() { Data = null, Code = (int)HttpStatusCode.InternalServerError, Error = "Thêm sản phẩm thất bại" });
            }
        }
        [HttpPost]
        //[Route("getproduct-paging")]
        //public async Task<IActionResult> GetProductPagingnate(string sortOrder, string curentFilter, string searchString, int? page)
        //{
        //    return Ok();
        //}
        [HttpPost]
        [Route("getproduct-paging")]
        public async Task<IActionResult> GetProductPageList(PagingParams pagingParams)
        {
            var data = _productService.GetProductPageList(pagingParams);
            _logger.LogInformation("dữ liệu vào: " + pagingParams.SearchString);
            Response.Headers.Add("X-Pagination", data.GetHeader().ToJson());
            var output = new OutPutModel<Product>
            {
                Paging = data.GetHeader(),
                Items = data.List.ToList(),
            };
            return Ok(new Result() { Code = 200, Data = output, Error = null });
        }
        [HttpPost]
        [Route("update-product-type")]
        public async Task<IActionResult> UpdateProduct(List<Guid> id)
        {
            List<Product> products = new List<Product>();
            foreach (var item in id)
            {
                var product = await _productService.GetFirstOrDefault(item);
                products.Add(product);

            }
            _productService.UpdateProduct(products);
            return Ok();
        }
        [HttpPost]
        [Route("get-product-type")]
        public async Task<IActionResult> GetAllProduct()
        {
            var provider = _productService.GetAllProduct();
            return Ok();
        }
        [HttpPost]
        [Route("delete-product-type")]
        public async Task<IActionResult> DeleteProduct(List<ProductId> id)
        {
            try
            {
                List<Product> products = new List<Product>();
                foreach (var item in id)
                {
                    var provider = await _productService.FindProductById(item.Id);
                    products.Add(provider);
                }
                _productService.DeleteProduct(products);
                return Ok(new Result() { Code = 200, Data = "Xóa sản phẩm thành công", Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Thêm sản phẩm thất bại: " + ex);
                return Ok(new Result() { Code = ex.GetHashCode(), Data = "Xóa sản phẩm thành công", Error = null });
            }
        }
        [HttpPost]
        [Route("find-product-type")]
        public async Task<IActionResult> FindProductById(Guid id)
        {
            await _productService.FindProductById(id);
            return Ok();
        }
        [HttpPost]
        [Route("get-product-paging")]
        public async Task<IActionResult> GetProductPaging(PagingParams pagingParams)
        {
            _productService.GetAllProductPaging();
            try
            {
                var data = _productService.GetProductPageList(pagingParams);
                Response.Headers.Add("X-Pagination", data.GetHeader().ToJson());
                var output = new OutPutModel<Product>
                {
                    Paging = data.GetHeader(),
                    Items = data.List.ToList(),
                };
                return Ok(new Result() { Code = 200, Data = output, Error = null });
            }
            catch (Exception ex)
            {
                return Ok(new Result() { Code = ex.HResult, Data = null, Error = "Lỗi lấy dữ liệu phân trang" });
            }
        }
    }
}