using CRUD_Products.Models.Login.Models.Request;
using CRUD_Products.Models.Login.Models.Response;
using CRUD_Products.Models.Login.Service;
using CRUD_Products.Models.Products.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Products.Controllers.User
{
    [Route("v1/login")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginApiController(
            ILoginService loginService) 
        {
            _loginService = loginService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetLoginAsync(
            LoginRequest request)
        {
            var result = await _loginService.LoginAsync(request);

            return Ok(result);
        }
    }
}
