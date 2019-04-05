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
    public class StatusCartsController : ControllerBase
    {
        private readonly IStatusCartsService _statusCartsService;
        private readonly ILogger<StatusCartsController> _logger;
        public StatusCartsController(
            IStatusCartsService statusCartsService,
            ILogger<StatusCartsController> logger
            )
        {
            _statusCartsService = statusCartsService;
            _logger = logger;
        }
        [HttpPost]
        [Route("insert-status-cart")]
        public async Task<IActionResult> InsertStatusCarts(StatusCart statusCart)
        {
            try
            {
                _statusCartsService.InsertStatusCart(statusCart);
                return Ok(new Result() { Data = "Thêm tình trạng giỏi hàng thành công thành công", Code = 200, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Thêm trạng thái giỏ hàng thất bại: " + ex);
                return Ok(new Result() { Data = "Thêm tình trạng giỏi hàng thành công thành công", Code = 200, Error = ex.Message });
            }
        }
        [HttpPost]
        [Route("get-statuscart")]
        public async Task<IActionResult> GetAllProductType()
        {
            try
            {
                var productType = _statusCartsService.GetAllRecords();
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = productType, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy danh sách loại sản phẩm : " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = "Lỗi lấy danh sách loại sản phẩm" });
            }
        }
    }
}