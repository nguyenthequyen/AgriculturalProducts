using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ProductTypeAdminController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        private readonly ILogger _logger;
        public ProductTypeAdminController(
            IProductTypeService productTypeService,
            ILogger<ProductTypeAdminController> logger
        )
        {
            _productTypeService = productTypeService;
            _logger = logger;
        }
        [HttpPost]
        [Route("inssert-product-type")]
        public async Task<IActionResult> InsertProductType(List<ProductType> productType)
        {
            try
            {
                _productTypeService.InsertProductType(productType);
                return Ok(new Result() { Code = 200, Data = "Thêm loại sản phẩm thành công", Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi thêm loại sản phẩm+ " + ex);
                return Ok(new Result() { Code = ex.HResult, Data = null, Error = "Lỗi thêm loại sản phẩm" });
            }
        }
        [HttpPost]
        [Route("update-product-type")]
        public async Task<IActionResult> UpdateProductType(List<Guid> id)
        {
            List<ProductType> products = new List<ProductType>();
            foreach (var item in id)
            {
                var product = await _productTypeService.FindProductTypeById(item);
                products.Add(product);
            }
            _productTypeService.UpdateProductType(products);
            return Ok();
        }
        [HttpPost]
        [Route("get-product-type")]
        public async Task<IActionResult> GetAllProductType()
        {
            var provider = _productTypeService.GetAllProductType();
            return Ok();
        }
        [HttpPost]
        [Route("delete-product-type")]
        public async Task<IActionResult> DeleteProductType(List<ProductType> provider)
        {
            _productTypeService.DeleteProductType(provider);
            return Ok();
        }
        [HttpPost]
        [Route("find-product-type")]
        public async Task<IActionResult> FindProductTypeById(Guid id)
        {
            await _productTypeService.FindProductTypeById(id);
            return Ok();
        }
        [HttpPost]
        [Route("get-product-type-paging")]
        public async Task<IActionResult> GetProductTypePaging(PagingParams pagingParams)
        {
            try
            {
                var data = _productTypeService.GetroductTypePageList(pagingParams);
                _logger.LogInformation("dữ liệu vào: " + pagingParams.SearchString);
                Response.Headers.Add("X-Pagination", data.GetHeader().ToJson());
                var output = new OutPutModel<ProductType>
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