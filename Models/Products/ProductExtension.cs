using CRUD_Products.Models.Products.Repository;
using CRUD_Products.Models.Products.Service;
using SimpleInjector;

namespace CRUD_Products.Models.Products
{
    public static class ProductExtension
    {
        public static void UseProduct(
            this SimpleInjector.Container container)
        {
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Singleton);
            container.Register<IProductService, ProductService>(Lifestyle.Singleton);
        }
    }
}
