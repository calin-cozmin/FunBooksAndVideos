using FunBooksAndVideos.Enums;

namespace FunBooksAndVideos.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public OrderStatus Status { get; set; }

        public int UserId { get; set; }

        public UserModel User { get; set; }

        public int PaymentTypeId { get; set; }

        public PaymentTypeModel PaymentType { get; set; }

        public List<OrderItemModel> OrderItems { get; set; }
    }
}
