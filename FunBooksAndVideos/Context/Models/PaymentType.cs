using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Context.Models
{
    public class PaymentType
    {
        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Description { get; set; }

        [Required] public Enums.PaymentType Type { get; set; }

        public Order Order { get; set; }
    }
}
