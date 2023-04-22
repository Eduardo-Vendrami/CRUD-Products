using CRUD_Products.Models.Login.Models.Request;
using CRUD_Products.Models.Login.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Products.Models.Login.Service
{
    public interface ILoginService
    {
        public Task<ActionResult<LoginResponse>> LoginSignInAsync(
            LoginRequest loginRequest);

        public Task<ActionResult<string>> LoginSignUpAsync(
            LoginRequest loginRequest);

        public Task<ActionResult<LoginResponse>> LoginUpdateAsync(
            LoginRequest loginRequest);
        public Task<ActionResult<LoginResponse>> LoginForgetPasswordAsync(
            LoginRequest loginRequest);
    }
}
