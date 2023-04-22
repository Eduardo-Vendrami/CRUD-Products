using CRUD_Products.Models.Products.Models;

namespace CRUD_Products.Models.Products.Repository
{
    public interface IProductRepository
    {
        public Task<int> RegisterProductAsync(
            ProductRequest product);

        public Task<IEnumerable<ProductResponse>> ReadProductAsync(
            ProductRequest product);

        public Task<int> UpdateProductAsync(
            ProductRequest product);

        public Task<int> DeleteProductAsync(
            ProductRequest product);
    }
}
