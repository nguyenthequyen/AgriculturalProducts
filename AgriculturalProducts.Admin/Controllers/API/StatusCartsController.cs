using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturalProducts.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusCartsController : ControllerBase
    {
        private readonly IStatusCartsService _statusCartsService;
        public StatusCartsController(IStatusCartsService statusCartsService)
        {
            _statusCartsService = statusCartsService;
        }
        [HttpPost]
        [Route("insert-status-cart")]
        public async Task<IActionResult> InsertStatusCarts(StatusCart statusCart)
        {
            try
            {
                _statusCartsService.InsertStatusCart(statusCart);
                return Ok(new Result() { Data="Thêm tình trạng giỏi hàng thành công thành công", Code = 200, Error = null });
            }
            catch (Exception ex)
            {
                return Ok(new Result() { Data="Thêm tình trạng giỏi hàng thành công thành công", Code = 200, Error = ex.Message });
            }
        }
    }
}