using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.Web.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdiverAdminController : ControllerBase
    {
        private readonly IProviderService _providerService;
        private readonly ILogger _logger;
        public ProdiverAdminController(
            IProviderService providerService,
             ILogger<ProdiverAdminController> logger
            )
        {
            _providerService = providerService;
            _logger = logger;
        }
        [HttpPost]
        [Route("insert-provider")]
        public async Task<IActionResult> InsertProduct(Provider provider)
        {
            _providerService.InsertProvider(provider);
            _logger.LogInformation("Test Log");
            return Ok();
        }
        [HttpPost]
        [Route("update-provider")]
        public async Task<IActionResult> UpdateProvider(Provider provider)
        {
            _providerService.UpdateProvider(provider);
            return Ok();
        }
        [HttpPost]
        [Route("get-provider")]
        public async Task<IActionResult> GetAllProvider()
        {
            var provider = _providerService.GetAllProvider();
            return Ok();
        }
        [HttpPost]
        [Route("delete-provider")]
        public async Task<IActionResult> DeleteProvider(Provider provider)
        {
            _providerService.DeleteProvider(provider);
            return Ok();
        }
        [HttpPost]
        [Route("find-provider")]
        public async Task<IActionResult> FindProductById(Guid id)
        {
            await _providerService.FindProviderById(id);
            return Ok();
        }
    }
}