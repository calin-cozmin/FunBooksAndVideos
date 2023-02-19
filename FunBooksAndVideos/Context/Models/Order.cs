using System.ComponentModel.DataAnnotations;
using FunBooksAndVideos.Enums;

namespace FunBooksAndVideos.Context.Models
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        [Key] public int Id { get; set; }

        [Required] public decimal Amount { get; set; }

        [Required] public OrderStatus Status { get; set; }

        [Required] public int UserId { get; set; }

        public User User { get; set; }

        [Required] public int PaymentTypeId { get; set; }

        public PaymentType PaymentType { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
