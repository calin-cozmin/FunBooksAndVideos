namespace FunBooksAndVideos.Models
{
    public class PaymentTypeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Enums.PaymentType Type { get; set; }
    }
}
