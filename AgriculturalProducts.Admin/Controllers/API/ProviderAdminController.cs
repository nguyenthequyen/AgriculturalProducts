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

namespace AgriculturalProducts.Web.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderAdminController : ControllerBase
    {
        private readonly IProviderService _providerService;
        private readonly ILogger _logger;
        public ProviderAdminController(
            IProviderService providerService,
             ILogger<ProviderAdminController> logger
            )
        {
            _providerService = providerService;
            _logger = logger;
        }
        [HttpPost]
        [Route("insert-provider")]
        public async Task<IActionResult> InsertProduct(List<Provider> provider)
        {
            _providerService.InsertProvider(provider);
            _logger.LogInformation("Test Log");
            return Ok();
        }
        [HttpPost]
        [Route("update-provider")]
        public async Task<IActionResult> UpdateProvider(List<Guid> id)
        {
            List<Provider> providers = new List<Provider>();
            foreach (var item in id)
            {
                var provider = await _providerService.FindProviderById(item);
                providers.Add(provider);
            }
            _providerService.UpdateProvider(providers);
            return Ok();
        }
        [HttpPost]
        [Route("get-all-provider")]
        public async Task<IActionResult> GetAllProvider()
        {
            try
            {
                var provider = _providerService.GetAllProvider();
                return Ok(new Result() { Code = 200, Data = provider, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu tất cả nhà cung cấp: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error="Lỗi lấy dữ liệu nhà cung cấp" });
            }
        }
        [HttpPost]
        [Route("delete-provider")]
        public async Task<IActionResult> DeleteProvider([FromBody] List<ProviderId> id)
        {
            List<Provider> providers = new List<Provider>();
            foreach (var item in id)
            {
                var provider = await _providerService.FindProviderById(item.Id);
                providers.Add(provider);
            }
            _providerService.DeleteProvider(providers);
            return Ok();
        }
        [HttpPost]
        [Route("find-provider")]
        public async Task<IActionResult> FindProductById(Guid id)
        {
            await _providerService.FindProviderById(id);
            return Ok();
        }
        [HttpPost]
        [Route("getprovider-paging")]
        public async Task<IActionResult> GetProviderPageList(PagingParams pagingParams)
        {
            var data = _providerService.GetProviderPageList(pagingParams);
            _logger.LogInformation("dữ liệu vào: " + pagingParams.SearchString);
            Response.Headers.Add("X-Pagination", data.GetHeader().ToJson());
            var output = new OutPutModel<Provider>
            {
                Paging = data.GetHeader(),
                Items = data.List.ToList(),
            };
            return Ok(new Result() { Code = 200, Data = output, Error = null });
        }
    }
}