using CRUD_Products.Models.DataAccess;
using CRUD_Products.Models.Products.Models;
using Dapper;
using System.Data.SqlClient;

namespace CRUD_Products.Models.Products.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConnection _connection;

        public ProductRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> RegisterProductAsync(
            ProductRequest product)
        {
            var connectionString = _connection.GetConnectionStringAppSettings();

            using (var connection = new SqlConnection(connectionString))
            {
                var parameters = new
                {
                    productName = product.ProductName,
                    price = product.Price,
                };

                var sql = @"INSERT INTO PRODUCTS
                                                (Product_Name,
                                                Price
                                                )
                            VALUES              
                                                (@productName,
                                                @price)";

                return await connection.ExecuteAsync(
                    sql,
                    parameters);
            }
        }

        public async Task<IEnumerable<ProductResponse>> ReadProductAsync(
            ProductRequest product)
        {
            var connectionString = _connection.GetConnectionStringAppSettings();

            using (var connection = new SqlConnection(connectionString))
            {
                var parameters = new
                {
                    productName = product.ProductName
                };

                var sql = @"SELECT PRODUCT_NAME As ProductName,
                            PRICE As Price,
                            PRODUCT_ID As ProductId
                            FROM PRODUCTS
                            WHERE PRODUCT_NAME = @productName";

                return await connection.QueryAsync<ProductResponse>(
                    sql,
                    parameters);
            }
        }

        public async Task<int> UpdateProductAsync(
            ProductRequest product)
        {
            var connectionString = _connection.GetConnectionStringAppSettings();

            using (var connection = new SqlConnection(connectionString))
            {
                var parameters = new
                {
                    productName = product.ProductName,
                    price = product.Price,
                    newProductName = product.NewProductName,
                    newPrice = product.NewPrice
                };

                string price = GetSetPrice(
                    product);

                string productName = GetSetProductName(
                    product);

                var sql = $@"UPDATE PRODUCTS
                            SET {productName}
                                {price}
                            WHERE PRODUCT_NAME = @productName";

                return await connection.ExecuteAsync(
                    sql,
                    parameters);
            }
        }

        private static string GetSetPrice(
            ProductRequest product)
        {
            return product.NewPrice != null ? " PRICE = @newPrice " : string.Empty;
        }

        private static string GetSetProductName(
            ProductRequest product)
        {
            return product.NewProductName != null && product.NewPrice != null 
                ? " PRODUCT_NAME = @newProductName, "
                : product.Price != null 
                ? " PRODUCT_NAME = @newProductName "
                : string.Empty;
        }

        public async Task<int> DeleteProductAsync(
            ProductRequest product)
        {
            var connectionString = _connection.GetConnectionStringAppSettings();

            using (var connection = new SqlConnection(connectionString))
            {
                var parameters = new
                {
                    productId = product.ProductId
                };

                string price = GetSetPrice(
                    product);

                string productName = GetSetProductName(
                    product);

                var sql = $@"DELETE 
                             FROM PRODUCTS
                             WHERE PRODUCT_ID = @productId";

                return await connection.ExecuteAsync(
                    sql,
                    parameters);
            }
        }
    }
}
