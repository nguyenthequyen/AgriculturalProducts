using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.APIWeb.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<CommentController> _logger;
        public CommentController(
            ICommentService commentService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<CommentController> logger)
        {
            _commentService = commentService;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        [Route("created-comment")]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> CreatedComment(Comments comments)
        {
            try
            {
                var claimsIdentity = _httpContextAccessor.HttpContext.User.Claims;
                var data = new UsersInfor();
                var userId = claimsIdentity.FirstOrDefault(x => x.Type == "UserId").Value;
                var userName = claimsIdentity.FirstOrDefault(x => x.Type == "UserName").Value;
                comments.UserId = Guid.Parse(userId);
                _commentService.CreatedComment(comments);
                _logger.LogError("Tạo comment thành công");
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = "Thêm bình luận thành công", Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Tạo comment thất bại: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, Error = "Thêm bình luận thất bại" });
            }
        }
        [HttpPost]
        [Route("get-comment-byproductId")]
        public async Task<IActionResult> GetCommentByProductId([FromBody]ProductId id)
        {
            try
            {
                var data = _commentService.GetAllComments(id.Id);
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = data, Error = null });
            }
            catch (Exception ex)
            {
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, Error = "Lấy bình luận thất bại" });
            }

        }
    }
}