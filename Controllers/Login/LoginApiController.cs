using CRUD_Products.Models.Login.Models.Request;
using CRUD_Products.Models.Login.Service;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Products.Controllers.Login
{
    [Route("v1/login")]
    public class LoginApiController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginApiController(
            ILoginService loginService)
        {
            _loginService = loginService;
        }

        [Route("enter")]
        [HttpGet]
        public async Task<IActionResult> GetLoginAsync(
            LoginRequest request)
        {
            var result = await _loginService.LoginAsync(
                    request);

            return Ok(result);
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> PostLoginAsync(
            LoginRequest request)
        {
            var result = await _loginService.LoginRegisterAsync(
                    request);

            return Ok(result);
        }
    }
}
