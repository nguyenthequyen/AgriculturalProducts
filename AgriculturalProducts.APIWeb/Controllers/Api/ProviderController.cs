using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.APIWeb.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;
        private readonly ILogger _logger;
        private readonly ApplicationContext _applicationContext;
        public ProviderController(
            IProviderService providerService,
            ApplicationContext applicationContext,
            ILogger<ProviderController> logger)
        {
            _applicationContext = applicationContext;
            _logger = logger;
            _providerService = providerService;
        }
        [HttpPost]
        [Route("insert-provider")]
        public async Task<IActionResult> InsertProduct(Provider provider)
        {
            _providerService.Add(provider);
            _logger.LogInformation("Test Log");
            return Ok();
        }
    }
}