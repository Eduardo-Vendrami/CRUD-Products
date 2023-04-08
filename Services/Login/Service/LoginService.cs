using CRUD_Products.Models.Login.Models;
using CRUD_Products.Models.Login.Models.Request;
using CRUD_Products.Models.Login.Models.Response;
using CRUD_Products.Models.Login.Repository;
using CRUD_Products.Services.Token.Service;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Products.Models.Login.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly ITokenService _tokenService;

        public LoginService(
            ILoginRepository loginRepository,
            ITokenService tokenService)
        {
            _loginRepository = loginRepository;
            _tokenService = tokenService;
        }

        public async Task<ActionResult<LoginResponse>> LoginAsync(
            LoginRequest loginRequest)
        {            
            var user = await GetLoginAsync(
                loginRequest);

            var response = await GetResponseLoginAsync(
                loginRequest, 
                user);           

            return response;
        }

        private async Task<LoginResponse> GetResponseLoginAsync(
            LoginRequest loginRequest, 
            User user)
        {
            LoginResponse response = new LoginResponse();

            if (loginRequest.Username == user.Username && loginRequest.Password == user.Password)
            {
                var token = _tokenService.GenerateToken(
                user);

                response = new LoginResponse
                {
                    IsSuccess= true,
                    Username = user.Username,
                    Token = token,
                };
            }
            else
            {
                response = new LoginResponse
                {
                    IsSuccess = false,
                    Message = "Usuário ou senha incorreto."
                };
            }            

            return response;
        }

        private async Task<User> GetLoginAsync(
            LoginRequest loginRequest)
        {
            var user = new User();

            try
            {
                user = await _loginRepository.LoginAsync(
                    loginRequest);
            }
            catch (Exception ex)
            {
                throw;
            }

            return user;
        }

        public async Task<ActionResult<string>> LoginRegisterAsync(
            LoginRequest loginRequest)
        {
            var returnTrue = "Usuário cadastrado";

            var profile = await GetProfile(
                loginRequest);

            await RegisterLoginAsync(
                loginRequest,
                profile);

            return returnTrue;
        }

        private async Task<string> GetProfile(
            LoginRequest loginRequest)
        {
            var profile = string.Empty;

            if (loginRequest.IsSeller)
            {
                profile = Profiles.Seller.ToString();
            }
            else if (loginRequest.IsCustomer)
            {
                profile = Profiles.Customer.ToString();
            }

            return profile;
        }

        private async Task RegisterLoginAsync(
            LoginRequest loginRequest,
            string profile)
        {
            try
            {
                await _loginRepository.LoginRegisterAsync(
                    loginRequest,
                    profile);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
