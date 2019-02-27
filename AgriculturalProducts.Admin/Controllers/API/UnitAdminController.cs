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
    public class UnitAdminController : ControllerBase
    {
        private readonly IUnitService _unitService;
        public UnitAdminController(IUnitService unitService)
        {
            _unitService = unitService;
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
    }
}