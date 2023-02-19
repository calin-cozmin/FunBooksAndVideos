namespace FunBooksAndVideos.Models
{
    public class OrderItemModel
    {
        public int Id { get; set; }

        public int NumberOfItemsInOrder { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }
    }
}
