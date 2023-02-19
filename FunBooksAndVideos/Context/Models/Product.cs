using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Context.Models
{
    public class Product
    {
        [Key] public int Id { get; set; }

        [Required] public string Title { get; set; }

        [Required] public string Description { get; set; }

        [Required] public bool IsActive { get; set; }

        [Required] public decimal Price { get; set; }

        [Required] public string CurrencyCode { get; set; }

        [Required] public int ProductCategoryId { get; set; }

        public ProductCategory ProductCategory { get; set; }

        [Required] public int ProductStockId { get; set; }

        public ProductStock ProductStock { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
