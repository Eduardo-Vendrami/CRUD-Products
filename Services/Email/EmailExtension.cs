using CRUD_Products.Services.Email.Service;
using CRUD_Products.Services.Token.Service;
using SimpleInjector;

namespace CRUD_Products.Services.Email
{
    public static class EmailExtension
    {
        public static void UseEmail(
            this Container container)
        {
            container.Register<IEmailService, EmailService>(Lifestyle.Singleton);
        }
    }
}
