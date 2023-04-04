using CRUD_Products.Models.Products.Models;
using CRUD_Products.Models.Products.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace CRUD_Products.Models.Products.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository; 

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        } 

        public async Task<ActionResult<string>> RegisterProductAsync(
            ProductRequest product)
        {
            var retornoTrue = "Produto cadastrado com sucesso.";
            var retornoFalse = "Produto não cadastrado.";

            var result = await RegisterProduct(product);

            var response = GetResponseCreate(
                retornoTrue, 
                retornoFalse,
                result);

            return response;
        }

        private static string GetResponseCreate(
            string retornoTrue,
            string retornoFalse, 
            int result)
        {
            return result >= 1 ? retornoTrue : retornoFalse;
        }
        private async Task<int> RegisterProduct(
            ProductRequest product)
        {
            var result = 0;

            try
            {
                result = await _productRepository.RegisterProductAsync(
                product);
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public async Task<ActionResult<ProductResponse>> ReadProductAsync(
            ProductRequest product)
        {
            var result = await ReadProduct(product);

            var response = await GetReponseRead(result);

            return response;
        }

        private async Task<ProductResponse> GetReponseRead(
            IEnumerable<ProductResponse> product)
        {
            var response = new ProductResponse();

            response.ProductName = product.FirstOrDefault().ProductName;
            response.Price = product.FirstOrDefault().Price;
            response.ProductId = product.FirstOrDefault().ProductId;

            return response;
        }

        private async Task<IEnumerable<ProductResponse>> ReadProduct(
            ProductRequest product)
        {
            IEnumerable<ProductResponse> response = new List<ProductResponse>();

            try
            {
                response = await _productRepository.ReadProductAsync(
                product);
            }
            catch (Exception ex)
            {
                throw;
            }

            return response;
        }

        public async Task<ActionResult<string>> UpdateProductAsync(
            ProductRequest product)
        {
            var retornoTrue = "Produto atualizado com sucesso.";
            var retornoFalse = "Produto não atualizado.";

            var result = await UpdateProduct(product);

            var response = await GetReponseUpdate(
                retornoTrue, 
                retornoFalse, 
                result);

            return response;
        }

        private async Task<int> UpdateProduct(
            ProductRequest product)
        {
            var response = 0;

            try
            {
                response = await _productRepository.UpdateProductAsync(
                product);
            }
            catch (Exception ex)
            {
                throw;
            }

            return response;
        }

        private async Task<string> GetReponseUpdate(
            string retornoTrue,
            string retornoFalse,
            int result)
        {
            return result >= 1 ? retornoTrue : retornoFalse;
        }

        public async Task<ActionResult<string>> DeleteProductAsync(ProductRequest product)
        {
            var retornoTrue = "Produto deletado com sucesso.";
            var retornoFalse = "Produto não deletado.";

            var result = await DeleteProduct(product);

            var response = await GetReponseDelete(
                retornoTrue,
                retornoFalse,
                result);

            return response;
        }

        private async Task<int> DeleteProduct(
            ProductRequest product)
        {
            var response = 0;

            try
            {
                response = await _productRepository.DeleteProductAsync(
                product);
            }
            catch (Exception ex)
            {
                throw;
            }

            return response;
        }

        private async Task<string> GetReponseDelete(
            string retornoTrue,
            string retornoFalse,
            int result)
        {
            return result >= 1 ? retornoTrue : retornoFalse;
        }


    }
}
