using CRUD_Products.Models.Product.Service;
using CRUD_Products.Models.Products.Repository;
using CRUD_Products.Services.Token.Service;
using SimpleInjector;

namespace CRUD_Products.Services.Token
{
    public static class TokenExtension
    {
        public static void UseToken(
            this Container container)
        {
            container.Register<ITokenService, TokenService>(Lifestyle.Singleton);
        }
    }
}
