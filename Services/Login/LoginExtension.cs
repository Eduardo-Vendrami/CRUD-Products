using CRUD_Products.Models.Login.Repository;
using CRUD_Products.Models.Login.Service;
using CRUD_Products.Models.Product.Service;
using CRUD_Products.Models.Products.Repository;
using SimpleInjector;

namespace CRUD_Products.Models.Login
{
    public static class LoginExtension
    {
        public static void UseLogin(
            this SimpleInjector.Container container)
        {
            container.Register<ILoginService, LoginService>(Lifestyle.Singleton);
            container.Register<ILoginRepository, LoginRepository>(Lifestyle.Singleton);
        }
    }
}
