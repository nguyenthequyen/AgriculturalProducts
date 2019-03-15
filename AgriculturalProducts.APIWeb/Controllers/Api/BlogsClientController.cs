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
    public class BlogsClientController : ControllerBase
    {
        private readonly IBlogsService _blogsService;
        private readonly ILogger<BlogsClientController> _logger;
        public BlogsClientController(IBlogsService blogsService, ILogger<BlogsClientController> logger)
        {
            _blogsService = blogsService;
            _logger = logger;
        }
        [HttpPost]
        [Route("get-top-blogs")]
        public async Task<IActionResult> GetBlogsTopNews()
        {
            try
            {
                var data = _blogsService.GetBlogsTopNews();
                _logger.LogError("Ghi log thành công");
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = data, Error = null });
            }
            catch (Exception ex)
            {
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = ex.Message });
            }
        }
    }
}