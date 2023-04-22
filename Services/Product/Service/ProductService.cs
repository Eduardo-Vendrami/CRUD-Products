using CRUD_Products.Models.Products.Models;
using CRUD_Products.Models.Products.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace CRUD_Products.Models.Product.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository; 

        public ProductService(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        } 

        public async Task<ActionResult<string>> RegisterProductAsync(
            ProductRequest product)
        {
            

            var result = await RegisterProduct(
                product);

            var response = await GetResponseCreate(
                result);

            return response;
        }

        private async Task<string> GetResponseCreate(
            int result)
        {
            var retornoTrue = "Produto cadastrado com sucesso.";
            var retornoFalse = "Produto não cadastrado.";

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

        public async Task<ActionResult<IEnumerable<ProductResponse>>> ReadProductAsync(
            ProductRequest product)
        {
            var result = await GetProductAsync(
                product);

            return result.ToList();
        }

        private async Task<IEnumerable<ProductResponse>> GetProductAsync(
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
            

            var result = await ModifyProductAsync(
                product);

            var response = await GetReponseUpdateAsync(
                result);

            return response;
        }

        private async Task<int> ModifyProductAsync(
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

        private async Task<string> GetReponseUpdateAsync(
            int result)
        {
            var retornoTrue = "Produto atualizado com sucesso.";
            var retornoFalse = "Produto não atualizado.";

            return result >= 1 ? retornoTrue : retornoFalse;
        }

        public async Task<ActionResult<string>> DeleteProductAsync(ProductRequest product)
        {
            var result = await RemoveProductAsync(product);

            var response = await GetReponseDeleteAsync(
                result);

            return response;
        }

        private async Task<int> RemoveProductAsync(
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

        private async Task<string> GetReponseDeleteAsync(
            int result)
        {
            var retornoTrue = "Produto deletado com sucesso.";
            var retornoFalse = "Produto não deletado.";

            return result >= 1 ? retornoTrue : retornoFalse;
        }


    }
}
