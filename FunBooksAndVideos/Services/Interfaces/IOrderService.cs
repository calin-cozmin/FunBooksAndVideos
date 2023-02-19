using FunBooksAndVideos.Models;

namespace FunBooksAndVideos.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderModel>> GetAllOrders();

        Task<OrderModel> GetOrderById(int orderId);
    }
}
