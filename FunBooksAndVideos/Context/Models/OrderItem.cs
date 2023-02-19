﻿using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Context.Models
{
    public class OrderItem
    {
        [Key] public int Id { get; set; }

        [Required] public int NumberOfItemsInOrder { get; set; }

        [Required] public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required] public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
