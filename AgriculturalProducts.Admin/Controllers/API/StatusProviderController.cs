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

namespace AgriculturalProducts.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusProviderController : ControllerBase
    {
        private readonly IStatusProviderService _statusProviderService;
        private readonly ILogger<StatusProviderController> _logger;
        public StatusProviderController(
            IStatusProviderService statusProductService,
             ILogger<StatusProviderController> logger
            )
        {
            _statusProviderService = statusProductService;
            _logger = logger;
        }
        [HttpPost]
        [Route("insert-status-provider")]
        public async Task<IActionResult> InsertStatusProvider(List<StatusProvider> statusProvider)
        {
            try
            {
                _statusProviderService.InsertStatusProvider(statusProvider);
                return Ok(new Result() { Code = 200, Data = "Thêm tình trạng nhà cung cấp thành công", Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi Thêm tình trạng nhà cung cấp thất bại: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = "Thêm tình trạng nhà cung cấp thất bại" });
            }
        }
        [HttpPost]
        [Route("get-all-status-provider")]
        public async Task<IActionResult> GetAllProvider()
        {
            try
            {
                var statusProducts = _statusProviderService.GetAllStatusProvider();
                return Ok(new Result() { Code = 200, Data = statusProducts, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu tình trạng nhà cung cấp: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = "Lỗi lấy dữ liệu tình trạng nhà cung cấp" });
            }
        }
    }
}