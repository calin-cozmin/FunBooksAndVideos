using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Context.Models
{
    public class ProductCategory
    {
        [Key] public int Id { get; set; }

        [Required]  public string Name { get; set; }

        [Required] public bool IsActive { get; set; }

        public Product Product { get; set; }
    }
}
