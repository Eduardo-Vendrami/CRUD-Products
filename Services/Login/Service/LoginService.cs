using Azure.Core;
using CRUD_Products.Models.Login.Models;
using CRUD_Products.Models.Login.Models.Request;
using CRUD_Products.Models.Login.Models.Response;
using CRUD_Products.Models.Login.Repository;
using CRUD_Products.Services.Token.Service;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

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

        public async Task<ActionResult<LoginResponse>> LoginSignInAsync(
            LoginRequest loginRequest)
        {            
            var user = await _loginRepository.LoginAsync(
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

        public async Task<ActionResult<string>> LoginSignUpAsync(
            LoginRequest loginRequest)
        {
            var returnTrue = "Usuário cadastrado";

            var profile = await GetProfile(
                loginRequest);

            await _loginRepository.LoginRegisterAsync(
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

        public async Task<ActionResult<LoginResponse>> LoginUpdateAsync(
            LoginRequest loginRequest)
        {
            var result = new LoginResponse();
            var messageFalse = "Nome de usuário já existente.";
            var messageTrue = "Informações atualizadas.";

            var existingUser = await ValidateUExistingUserAsync(
                loginRequest);

            if (existingUser.IsSuccess = true) 
            {
                return result = new LoginResponse()
                {
                    IsSuccess = false,
                    Message = messageFalse
                };
            }

            var updateUser = await _loginRepository.UpdateUserAsync(
                loginRequest);

            if (updateUser >= 1)
            {
                result = new LoginResponse() 
                {
                    IsSuccess = true,
                    Message = messageTrue
                };
            }

            return result;
        }

        private async Task<LoginResponse> ValidateUExistingUserAsync(
            LoginRequest loginRequest)
        {
            var existingUser = new User();
            var result = new LoginResponse();

            existingUser = await _loginRepository.ValidateUserAsync(
                loginRequest);

            if (existingUser.Username == loginRequest.Username)
                result.IsSuccess= false;

            result.IsSuccess = true;

            return result;
        }

        public Task<ActionResult<LoginResponse>> LoginForgetPasswordAsync(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }
    }
}
