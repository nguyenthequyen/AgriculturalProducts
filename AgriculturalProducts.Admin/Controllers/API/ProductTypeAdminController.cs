using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.Web.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Owner,Admin")]
    public class ProductTypeAdminController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        private readonly ILogger<ProductTypeAdminController> _logger;
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
            try
            {
                List<ProductType> products = new List<ProductType>();
                foreach (var item in id)
                {
                    var product = await _productTypeService.FindProductTypeById(item);
                    products.Add(product);
                }
                _productTypeService.UpdateProductType(products);
                return Ok(new Result() { Code = 200, Data = "Sửa loại sản phẩm thành công", Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Sửa loại sản phẩm thất bại: " + ex);
                return Ok(new Result() { Code = 200, Data = null, Error = ex.Message });
            }
        }
        [HttpPost]
        [Route("get-all-product-type")]
        public async Task<IActionResult> GetAllProductType()
        {
            try
            {
                var productType = _productTypeService.GetAllProductType();
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = productType, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy danh sách loại sản phẩm : " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = "Lỗi lấy danh sách loại sản phẩm" });
            }
        }
        [HttpPost]
        [Route("delete-product-type")]
        public async Task<IActionResult> DeleteProductType(List<ProductTypeId> id)
        {
            try
            {
                List<ProductType> productTypes = new List<ProductType>();
                foreach (var item in id)
                {
                    var provider = await _productTypeService.FindProductTypeById(item.Id);
                    productTypes.Add(provider);
                }
                _productTypeService.DeleteProductType(productTypes);
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = "Xóa loại sản phẩm thành công", Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Xóa lọai sản phẩm thất bại: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = "Lỗi lấy danh sách loại sản phẩm" });
            }
        }
        [HttpPost]
        [Route("find-product-type")]
        public async Task<IActionResult> FindProductTypeById(Guid id)
        {
            try
            {
                var data = await _productTypeService.FindProductTypeById(id);
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = data, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Tìm kiếm loại sản phẩm thất bại: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = ex.Message });
            }
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
                _logger.LogError("Lấy dữ liệu phân trang loại sản phẩm thất bại: " + ex);
                return Ok(new Result() { Code = ex.HResult, Data = null, Error = "Lỗi lấy dữ liệu phân trang" });
            }
        }
    }
}