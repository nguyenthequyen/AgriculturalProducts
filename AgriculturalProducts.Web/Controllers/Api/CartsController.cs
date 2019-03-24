using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Models.Common;
using AgriculturalProducts.Repository;
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
        private readonly ICartsMapperService _cartsMapperService;
        private readonly ApplicationContext _applicationContext;
        public CartsController(
            IProductClientService productClientService,
            ICartsMapperService cartsMapperService,
            ApplicationContext applicationContext,
            ILogger<CartsController> logger)
        {
            _productClientService = productClientService;
            _cartsMapperService = cartsMapperService;
            _applicationContext = applicationContext;
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
                ProductCart products = new ProductCart();
                var data = _applicationContext.Products.Where(x => x.Id == ids).Select(x => new
                {
                    Name = x.Name,
                    Id = x.Id,
                    Cost = x.Cost,
                    Image = _applicationContext.Images.Where(p => p.ProductId == x.Id).Select(img => new
                    {
                        Path = "data:image/png;base64, " + ConvertBase64.GetBase64StringForImage(img.Path)
                    })
                });
                foreach (var item in data)
                {
                    products.Id = item.Id;
                    products.Name = item.Name;
                    products.Cost = item.Cost;
                    foreach (var image in item.Image)
                    {
                        products.Path = image.Path;
                    }
                }
                if (products == null)
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
                            ProductCart = products,
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
                                ProductCart = products,
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
                if (cart[i].ProductCart.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
    }
}