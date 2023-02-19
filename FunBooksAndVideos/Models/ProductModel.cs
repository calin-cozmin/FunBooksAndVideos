using FunBooksAndVideos.Repositories.Base;

namespace FunBooksAndVideos.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public decimal Price { get; set; }

        public string CurrencyCode { get; set; }

        public int ProductCategoryId { get; set; }

        public ProductCategoryModel ProductCategory { get; set; }

        public int ProductStockId { get; set; }

        public ProductStockModel ProductStock { get; set; }

        public List<OrderItemModel> OrderItems { get; set; }
    }
}
