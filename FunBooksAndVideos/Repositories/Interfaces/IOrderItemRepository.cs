using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;

namespace FunBooksAndVideos.Repositories.Interfaces
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        Task<List<OrderItem>> GetOrderItems(int orderId);

        Task AddOrderItem(OrderItem orderItem);

        void UpdateOrderItem(OrderItem orderItem);
    }
}
