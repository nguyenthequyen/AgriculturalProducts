using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
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
    //[Authorize(Roles = "Owner,Admin")]
    public class OrderAdminController : ControllerBase
    {
        private readonly IOrderAdminService _orderAdminService;
        private readonly IOrderDetailsAdminService _orderDetailsAdminService;
        private readonly IProductService _productService;
        private readonly ILogger<OrderAdminController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatusCartsService _statusCartsService;
        public OrderAdminController(
            IOrderAdminService orderAdminService,
            IOrderDetailsAdminService orderDetailsAdminService,
            IProductService productService,
            IUnitOfWork unitOfWork,
            IStatusCartsService statusCartsService,
            ILogger<OrderAdminController> logger
            )
        {
            _orderAdminService = orderAdminService;
            _orderDetailsAdminService = orderDetailsAdminService;
            _productService = productService;
            _logger = logger;
            _statusCartsService = statusCartsService;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("get-order-paging")]
        public async Task<IActionResult> GetOrderPagingnate([FromBody] PagingParams pagingParams)
        {
            try
            {
                var data = _orderAdminService.GetOrderPagingnate(pagingParams);
                Response.Headers.Add("X-Pagination", data.GetHeader().ToJson());
                var output = new OutPutModel<object>
                {
                    Paging = data.GetHeader(),
                    Items = data.List.ToList(),
                };
                return Ok(new Result() { Code = 200, Data = output, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu đơn hàng: " + ex);
                return Ok(new Result() { Code = ex.HResult, Data = null, Error = "Lỗi lấy dữ liệu phân trang" });
            }
        }
        [HttpPost]
        [Route("order-details")]
        [ValidateModel]
        public async Task<IActionResult> GetDetailsOrder([FromBody] PagingParamsOrderId pagingParams)
        {
            try
            {
                var data = _orderAdminService.GetOrderDetailsPagingnate(pagingParams);
                Response.Headers.Add("X-Pagination", data.GetHeader().ToJson());
                var output = new OutPutModel<object>
                {
                    Paging = data.GetHeader(),
                    Items = data.List.ToList(),
                };
                return Ok(new Result() { Code = 200, Data = output, Error = null, OrderId = pagingParams.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu chi tiết đơn hàng: " + ex);
                return Ok(new Result() { Code = ex.HResult, Data = null, Error = "Lỗi lấy dữ liệu phân trang" });
            }
        }
        [HttpPost]
        [Route("update-details-order")]
        public async Task<IActionResult> UpdateOrderDetails(UpdatOrderParam orderParam)
        {
            try
            {
                var orderDetails = await _orderDetailsAdminService.GetOrderDetailsById(orderParam.OrderDetailsId);
                var product = await _productService.FindProductById(orderParam.ProductId);
                var order = await _orderAdminService.GetFirstOrDefault(orderParam.OrderId);
                var statusProduct = await _statusCartsService.GetFirstOrDefault(orderParam.StatusCartId);
                if (orderParam.StatusCart != "Chờ xử lý")
                {
                    if (orderDetails != null && order != null && product != null)
                    {
                        product.Quantity = product.Quantity - orderParam.Quantity;
                        _productService.Update(product);
                        order.Processed = order.Processed + orderParam.Quantity;
                        _orderAdminService.Update(order);
                        orderDetails.StatusCartId = orderParam.StatusCartId;
                        _orderDetailsAdminService.Update(orderDetails);
                        _unitOfWork.Commit();
                        return Ok(new Result() { Code = 200, Data = "Cập nhật đơn hàng thành công", Error = null });
                    }
                }
                return Ok(new Result() { Code = 200, Data = "Bạn phải thay đổi tình trạng đơn hàng", Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi cập nhật đơn hàng: " + ex);
                return Ok(new Result() { Code = ex.HResult, Data = "Lỗi cập nhật đơn hàng", Error = "Lỗi cập nhật đơn hàng" });
            }
        }
    }
}