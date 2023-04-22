using CRUD_Products.Models.Base;

namespace CRUD_Products.Models.Products.Models
{
    public sealed class ProductResponse : BaseResponse
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public decimal? Price { get; set; }
    }
}
