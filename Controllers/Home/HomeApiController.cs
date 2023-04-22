using Azure.Core;
using CRUD_Products.Models.Product.Service;
using CRUD_Products.Models.Products.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Products.Controllers.Home
{
    [Route("v1/home")]
    public class HomeApiController : ControllerBase
    {
        private readonly IProductService _productService;

        public HomeApiController(IProductService productService) 
        {
            _productService = productService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetHomeAsync(
            ProductRequest request)
        {
            var response = new ProductResponse();
            var messageFalse = "Requisição inválida.";

            if (request.All)
                return Ok(await _productService.ReadProductAsync(request));

            response.Message = messageFalse;

            return Ok(response);
        }
    }
}
