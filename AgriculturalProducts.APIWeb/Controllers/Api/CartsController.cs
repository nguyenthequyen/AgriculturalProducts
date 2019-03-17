﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Helpers;
using AgriculturalProducts.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IProductClientService _productClientService;
        private readonly ILogger<CartsController> _logger;
        public CartsController(
            IProductClientService productClientService,
            ILogger<CartsController> logger)
        {
            _productClientService = productClientService;
            _logger = logger;
        }
        [HttpPost]
        [Route("add-product-to-carts")]
        public async Task<IActionResult> AddToCarts(ProductCarts id)
        {
            try
            {
                var getSession = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                var ids = new Guid(id.Id);
                var product = await _productClientService.GetFirstOrDefault(ids);
                if (product == null)
                {
                    return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = "Không tìm thấy sản phẩm", Error = "Không tìm thấy sản phẩm" });
                }
                else
                {
                    if (getSession == null)
                    {
                        List<Item> cart = new List<Item>();
                        cart.Add(new Item
                        {
                            Product = product,
                            Quantity = 1
                        });
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                    }
                    else
                    {
                        List<Item> cart = getSession;
                        int index = IsExist(ids);
                        if (index != -1)
                        {
                            cart[index].Quantity++;
                        }
                        else
                        {
                            cart.Add(new Item
                            {
                                Product = product,
                                Quantity = 1
                            });
                        }
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                    }
                    return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = "Thêm sản phẩm vào giỏ hàng thành công", Error = null });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Thêm sản phẩm vào giỏ hàng thất bại: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, Error = "Thêm sản phẩm vào giỏ hàng thất bại" });
            }
        }
        [HttpPost]
        [Route("get-carts-session")]
        public async Task<IActionResult> GetCartsSession()
        {
            try
            {
                var carts = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = carts, Error = null, Message = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Thêm sản phẩm vào giỏ hàng thất bại: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, Error = "Lấy thông tin giỏ hàng thất bại" });
            }
        }
        [HttpPost]
        [Route("remove-carts")]
        public async Task<IActionResult> RemoveCartsSession(ProductCarts id)
        {
            try
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = IsExist(Guid.Parse(id.Id));
                cart.RemoveAt(index);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                var carts = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = carts, Error = null, Message = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Xóa sản phẩm khỏi giỏ hàng thất bại: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, Error = "Xóa sản phẩm khỏi giỏ hàng thất bại" });
            }
        }
        #region private
        private int IsExist(Guid id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
    }
}