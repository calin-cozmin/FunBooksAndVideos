using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;

namespace FunBooksAndVideos.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetOrder();

        Task<Order?> GetOrderById(int orderId);

        Task AddOrder(Order order);

        void UpdateOrder(Order order);
    }
}
