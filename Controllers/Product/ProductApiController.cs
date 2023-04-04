using CRUD_Products.Models.Products.Models;
using CRUD_Products.Models.Products.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace CRUD_Products.Controllers.Product
{
    [Route("v1/products")]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductApiController(
            IProductService productService) 
        {
            _productService = productService;
        }

        [Route("create")]
        [HttpGet]
        public async Task<IActionResult> GetProduct(
            ProductRequest request)
        {
            var result = await _productService.RegisterProductAsync(request);

            return Ok(result);  
        }

        [Route("read")]
        [HttpPost]
        public async Task<IActionResult> PostProduct(
            [FromBody] ProductRequest request)
        {
            var result = await _productService.ReadProductAsync(request);

            return Ok(result);
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> PutProduct(
            [FromBody] ProductRequest request)
        {
            var result = await _productService.UpdateProductAsync(request);

            return Ok(result);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(
            ProductRequest request)
        {
            var result = await _productService.DeleteProductAsync(request);

            return Ok(result);
        }
    }
}
