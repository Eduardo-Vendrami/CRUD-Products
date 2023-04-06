using CRUD_Products.Models.Login.Models.Request;
using CRUD_Products.Models.Login.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Products.Models.Login.Service
{
    public class LoginService : ILoginService
    {
        public Task<ActionResult<LoginResponse>> LoginAsync(
            LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }
    }
}
