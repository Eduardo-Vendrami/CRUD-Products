using CRUD_Products.Models.Login.Models;

namespace CRUD_Products.Services.Token.Service
{
    public interface ITokenService
    {
        public string GenerateToken(User user);   
    }
}
