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
    public class CategoryAdminController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger _logger;
        public CategoryAdminController(
            ICategoryService categoryService,
            ILogger<ProductAdminController> logger
            )
        {
            _categoryService = categoryService;
            _logger = logger;
        }
        [HttpPost]
        [Route("insert-category")]
        public async Task<IActionResult> InsertCategory(List<Category> categories)
        {
            try
            {
                _categoryService.InsertCategory(categories);
                return Ok(new Result() { Code = 200, Data = "Thêm danh mục sản phẩm thành công", Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi thêm danh mục sản phẩm: " + ex.Message);
                return Ok(new Result() { Code = ex.HResult, Data = null, Error = "Thêm danh mục sản phẩm thất bại" });
            }
        }
        [HttpPost]
        [Route("get-categories-paging")]
        public async Task<IActionResult> GetCategoryPaging(PagingParams pagingParams)
        {
            try
            {
                var data = _categoryService.GetCategoryPageList(pagingParams);
                _logger.LogInformation("dữ liệu vào: " + pagingParams.SearchString);
                Response.Headers.Add("X-Pagination", data.GetHeader().ToJson());
                var output = new OutPutModel<Category>
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