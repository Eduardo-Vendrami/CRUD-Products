using CRUD_Products.Models.Login.Models.Request;
using CRUD_Products.Models.Login.Models.Response;
using CRUD_Products.Models.Login.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Products.Models.Login.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(
            ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<ActionResult<LoginResponse>> LoginAsync(
            LoginRequest loginRequest)
        {
            LoginResponse response = new LoginResponse();

            try
            {
                response = await _loginRepository.LoginAsync(loginRequest);
            }
            catch (Exception ex)
            {

                throw;
            }

            return response;  
        }

        public async Task<ActionResult<string>> LoginRegisterAsync(
            LoginRequest loginRequest)
        {
            var returnTrue = "Usuário cadastrado";

            try
            {
                await _loginRepository.LoginRegisterAsync(loginRequest);
            }
            catch (Exception ex)
            {

                throw;
            }

            return returnTrue;
        }
    }
}
