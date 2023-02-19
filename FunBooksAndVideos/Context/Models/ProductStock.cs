using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Context.Models
{
    public class ProductStock
    {
        [Key] public int Id { get; set; }

        [Required] public int NumberOfProductInStock { get; set; }

        public Product Product { get; set; }
    }
}
