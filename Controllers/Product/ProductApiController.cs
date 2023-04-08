using CRUD_Products.Models.Product.Service;
using Microsoft.AspNetCore.Mvc;
using CRUD_Products.Models.Products.Models;

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

        [Route("read")]
        [HttpGet]
        public async Task<IActionResult> GetProductAsync(
            ProductRequest request)
        {
            var result = await _productService.ReadProductAsync(
                    request);

            return Ok(result);
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> PostProductAsync(
            [FromBody] ProductRequest request)
        {
            if (request.ProductName == null)
                return BadRequest("Nome do produto não pode estar vazio.");

            var result = await _productService.RegisterProductAsync(
                    request);

            return Ok(result);
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> PutProductAsync(
            [FromBody] ProductRequest request)
        {
            var result = await _productService.UpdateProductAsync(
                    request);

            return Ok(result);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync(
            ProductRequest request)
        {
            var result = await _productService.DeleteProductAsync(
                    request);

            return Ok(result);
        }
    }
}
