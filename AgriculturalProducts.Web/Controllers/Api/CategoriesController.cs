using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoriesClientService _categoriesClientService;
        public CategoriesController(
            ILogger<CategoriesController> logger,
            ICategoriesClientService categoriesClientService)
        {
            _categoriesClientService = categoriesClientService;
            _logger = logger;
        }
        [HttpPost]
        [Route("get_categories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var data = _categoriesClientService.GetCategories();
                _logger.LogError("Lấy dữ liệu thành công");
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = data, Error = "" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lấy dữ liệu thất bại");
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, Error = ex.Message });
            }
        }
        [HttpPost]
        [Route("get_productby_categories")]
        public async Task<IActionResult> GetProductByCategories([FromBody] CategoryParam category)
        {
            try
            {
                var data = _categoriesClientService.GetProductByCategory(category.Id);
                _logger.LogError("Lấy dữ liệu thành công");
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = data, Error = "" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lấy dữ liệu thất bại");
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, Error = ex.Message });
            }
        }
    }
}