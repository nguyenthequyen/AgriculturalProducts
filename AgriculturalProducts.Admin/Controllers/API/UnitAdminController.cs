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
    public class UnitAdminController : ControllerBase
    {
        private readonly IUnitService _unitService;
        private readonly ILogger<UnitAdminController> _logger;
        public UnitAdminController(
            IUnitService unitService,
            ILogger<UnitAdminController> logger
            )
        {
            _unitService = unitService;
            _logger = logger;
        }
        [HttpPost]
        [Route("insert-unit")]
        public async Task<IActionResult> InsertUnit(List<Unit> units)
        {
            try
            {
                _unitService.InsertUnit(units);
                return Ok(new Result() { Code = 200, Data = "Thêm đơn vị thành công", Error = null });
            }
            catch (Exception ex)
            {
                return Ok(new Result() { Code = ex.GetHashCode(), Data = null, Error = "Thất bại" });
            }
        }
        [HttpPost]
        [Route("get-all-unit")]
        public async Task<IActionResult> GetAllUnits()
        {
            try
            {
                var units = _unitService.GetAllUnit();
                return Ok(new Result() { Code = 200, Data = units, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy đơn vị tính: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = "Lỗi lấy đơn vị tính" });
            }
        }
        [HttpPost]
        [Route("get-unit-paging")]
        public async Task<IActionResult> GetUnitPaging(PagingParams pagingParams)
        {
            try
            {
                var data = _unitService.GetUnitPageList(pagingParams);
                _logger.LogInformation("dữ liệu vào: " + pagingParams.SearchString);
                Response.Headers.Add("X-Pagination", data.GetHeader().ToJson());
                var output = new OutPutModel<Unit>
                {
                    Paging = data.GetHeader(),
                    Items = data.List.ToList(),
                };
                return Ok(new Result() { Code = 200, Data = output, Error = null });
            }
            catch (Exception ex)
            {
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = "Lỗi lấy dữ liệu phân trang" });
            }
        }
    }
}