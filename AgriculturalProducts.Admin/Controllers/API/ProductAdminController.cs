using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;

namespace AgriculturalProducts.Web.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Owner,Admin")]
    public class ProductAdminController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger<ProductAdminController> _logger;
        private readonly IImagesService _imagesService;
        private readonly IUnitOfWork _unitOfWork;
        public ProductAdminController(
            IProductService productService,
            IImagesService imagesService,
            IUnitOfWork unitOfWork,
            IHostingEnvironment hostingEnvironment,
            ILogger<ProductAdminController> logger)
        {
            _logger = logger;
            _productService = productService;
            _hostingEnvironment = hostingEnvironment;
            _imagesService = imagesService;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("insert-product")]
        public async Task<IActionResult> InsertProduct(List<Product> product)
        {
            try
            {
                _productService.InsertProduct(product);
                return Ok(new Result() { Data = "Thêm sản phẩm thành công", Code = 200, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi thêm sản phẩm: " + ex);
                return Ok(new Result() { Data = null, Code = (int)HttpStatusCode.InternalServerError, Error = "Thêm sản phẩm thất bại" });
            }
        }
        [HttpPost]
        [Route("getproduct-paging")]
        public async Task<IActionResult> GetProductPageList(PagingParams pagingParams)
        {
            try
            {
                var data = _productService.GetProductPageList(pagingParams);
                _logger.LogInformation("dữ liệu vào: " + pagingParams.SearchString);
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
                _logger.LogError("Lỗi lấy dữ liệu phân trang sản phẩm: " + ex);
                return Ok(new Result() { Code = 200, Data = null, Error = "Lỗi lấy dữ liệu phân trang sản phẩm" });
            }
        }
        [HttpPost]
        [Route("delete-productbyid")]
        public async Task<IActionResult> DeleteProduct(ProductId id)
        {
            try
            {
                var product = await _productService.FindProductById(id.Id);
                if (product != null)
                {
                    var image = _imagesService.FindImageById(id.Id);
                    foreach (var item in image)
                    {
                        _imagesService.DeleteImage(item);
                    }
                    _unitOfWork.Commit();
                    _productService.DeleteProduct(product);
                    return Ok(new Result() { Code = 200, Data = "Xóa sản phẩm thành công", Error = null });
                }
                else
                {
                    return Ok(new Result() { Code = 200, Data = null, Error = "Không tìm thấy sản phẩm" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Thêm sản phẩm thất bại: " + ex);
                return Ok(new Result() { Code = ex.GetHashCode(), Data = null, Error = "Xóa sản phẩm thất bại" });
            }
        }
        [HttpPost]
        [Route("get-product-byid")]
        public async Task<IActionResult> FindProductById(ProductId id)
        {
            try
            {
                var product = await _productService.FindProductById(id.Id);
                return Ok(new Result() { Code = 200, Data = product, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Tìm sản phẩm thất bại: " + ex);
                return Ok(new Result() { Code = ex.GetHashCode(), Data = null, Error = "Tìm sản phẩm thất bại" });
            }
        }
        [HttpPost]
        [Route("update-product")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            try
            {
                _productService.UpdateProduct(product);
                return Ok(new Result() { Code = 200, Data = "Sửa sản phầm thành công", Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi sửa sản phẩm: " + ex);
                return Ok(new Result() { Code = ex.GetHashCode(), Data = null, Error = "Sửa sản phẩm thất bại" });
            }
        }
        [HttpPost]
        [Route("get-product-paging")]
        public async Task<IActionResult> GetProductPaging(PagingParams pagingParams)
        {
            try
            {
                var data = _productService.GetProductPageList(pagingParams);
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
                _logger.LogError("Lỗi lấy dữ liệu phân trang: " + ex);
                return Ok(new Result() { Code = ex.HResult, Data = null, Error = "Lỗi lấy dữ liệu phân trang" });
            }
        }
        [HttpPost]
        [Route("insert-product-fromexcel")]
        public async Task<IActionResult> InsertDataFromFileExcel(IFormFile formFile)
        {
            try
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(@"F:\Upload", "FileExcel");
                if (!Directory.Exists("FileExcel"))
                {
                    Directory.CreateDirectory(newPath);
                }
                string fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                string reversed = new String(fileName.ToCharArray().Reverse().ToArray());
                var extension = reversed.Split(".");
                char[] fileNameArray = extension[0].ToCharArray();
                Array.Reverse(fileNameArray);
                var name = Guid.NewGuid();
                fileName = name + "." + String.Join("", fileNameArray);
                string fullPath = Path.Combine(newPath, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
                FileInfo fileInfo = new FileInfo(fullPath);
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets["Products"];
                    int totalRows = workSheet.Dimension.Rows;

                    List<Product> producList = new List<Product>();

                    for (int i = 2; i <= totalRows; i++)
                    {
                        producList.Add(new Product
                        {
                            Name = workSheet.Cells[i, 1].Value.ToString(),
                            Code = workSheet.Cells[i, 2].Value.ToString(),
                            View = int.Parse(workSheet.Cells[i, 3].Value.ToString()),
                            Status = int.Parse(workSheet.Cells[i, 4].Value.ToString()),
                            CostOld = int.Parse(workSheet.Cells[i, 5].Value.ToString()),
                            Cost = int.Parse(workSheet.Cells[i, 6].Value.ToString()),
                            Mass = int.Parse(workSheet.Cells[i, 7].Value.ToString()),
                            ShortDescription = workSheet.Cells[i, 8].Value.ToString(),
                            FullDescription = workSheet.Cells[i, 9].Value.ToString(),
                            Quantity = int.Parse(workSheet.Cells[i, 10].Value.ToString()),
                            Sale = int.Parse(workSheet.Cells[i, 11].Value.ToString()),
                            CategoryId = Guid.Parse(workSheet.Cells[i, 12].Value.ToString()),
                            ProviderId = Guid.Parse(workSheet.Cells[i, 13].Value.ToString()),
                            ProductTypeId = Guid.Parse(workSheet.Cells[i, 14].Value.ToString()),
                            UnitId = Guid.Parse(workSheet.Cells[i, 15].Value.ToString()),
                            StatusProductId = Guid.Parse(workSheet.Cells[i, 16].Value.ToString()),
                        });
                    }
                    _productService.InsertProductExcel(producList);
                }
                return Ok(new Result() { Code = 200, Data = "Thêm sản phẩm từ file excel thành công", Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Thêm sản phẩm từ file excel thất bại: " + ex);
                return Ok(new Result() { Code = ex.HResult, Data = null, Error = "Thêm sản phẩm từ file excel thất bại" });
            }

        }
    }
}