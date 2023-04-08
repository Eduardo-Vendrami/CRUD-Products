using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CRUD_Products.Models.Products.Models
{
    public class ProductRequest
    {
        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("price")]
        public decimal? Price { get; set; }

        [JsonProperty("productName")]
        public string NewProductName { get; set; }

        [JsonProperty("price")]
        public decimal? NewPrice { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }
    }
}
