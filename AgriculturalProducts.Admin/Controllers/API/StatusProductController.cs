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

namespace AgriculturalProducts.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Owner,Admin")]
    public class StatusProductController : ControllerBase
    {
        private readonly IStatusProductService _statusProductService;
        private readonly ILogger<StatusProductController> _logger;
        public StatusProductController(
            IStatusProductService statusProductService,
             ILogger<StatusProductController> logger
            )
        {
            _statusProductService = statusProductService;
            _logger = logger;
        }
        [HttpPost]
        [Route("insert-status-products")]
        public async Task<IActionResult> InsertStatusProcduct(List<StatusProduct> statusProducts)
        {
            try
            {
                _statusProductService.InsertStatusProduct(statusProducts);
                return Ok(new Result() { Code = 200, Data="Thêm tình trạng sản phẩm thành công", Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi thêm danh mục sản phẩm: " + ex.Message);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error="Thêm tình trạng sản phẩm thành công" });
            }
        }
        [HttpPost]
        [Route("get-all-status-products")]
        public async Task<IActionResult> GetAllProcduct()
        {
            try
            {
                var statusProducts = _statusProductService.GetAllStatusProduct();
                return Ok(new Result() { Code = 200, Data = statusProducts, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu tình trạng sản phẩm: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error="Lỗi lấy dữ liệu tình trạng sản phẩm" });
            }
        }
    }
}