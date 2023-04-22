using CRUD_Products.Models.Login.Models.Request;
using CRUD_Products.Models.Login.Service;
using Microsoft.AspNetCore.Authorization;
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

        [Route("signIn")]
        [HttpGet]
        public async Task<IActionResult> GetLoginSignInAsync(
            LoginRequest request)
        {
            var result = await _loginService.LoginSignInAsync(
                    request);
             
            return Ok(result);
        }

        [Route("signUp")]
        [HttpPost]
        public async Task<IActionResult> PostLoginSignUpAsync(
            LoginRequest request)
        {
            var result = await _loginService.LoginSignUpAsync(
                    request);

            return Ok(result);
        }

        [Route("update")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostLoginUpdateAsync(
            LoginRequest request)
        {
            var result = await _loginService.LoginUpdateAsync(
                    request);

            return Ok(result);
        }

        [Route("forgetPassword")]
        [HttpPost]
        public async Task<IActionResult> PostForgetPasswordAsync(
            LoginRequest request)
        {
            var result = await _loginService.LoginForgetPasswordAsync(
                    request);

            return Ok(result);
        }
    }
}
