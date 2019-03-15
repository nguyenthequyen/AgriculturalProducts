﻿using System;
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
    public class BlogsController : ControllerBase
    {
        private readonly IBlogsService _blogsService;
        private readonly ILogger<BlogsController> _logger;
        public BlogsController(IBlogsService blogsService, ILogger<BlogsController> logger)
        {
            _blogsService = blogsService;
            _logger = logger;
        }
        [HttpPost]
        [Route("created-blogs")]
        public async Task<IActionResult> CreatedBlogs([FromBody]Blogs blogs)
        {
            try
            {
                _blogsService.CreatedBlogs(blogs);
                _logger.LogError("Ghi log thành công");
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = "Tạo bài viết thành công", Error = null });
            }
            catch (Exception ex)
            {
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = "Tạo bài viết thất bại", Error = ex.Message });
            }
        }
    }
}