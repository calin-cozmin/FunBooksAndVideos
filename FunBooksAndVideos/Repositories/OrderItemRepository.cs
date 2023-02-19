using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem, FunBooksAndVideosDbContext>, IOrderItemRepository
    {
        public OrderItemRepository(Lazy<FunBooksAndVideosDbContext> context) : base(context)
        {
        }

        public async Task<List<OrderItem>> GetOrderItems(int orderId)
        {
            return await DbSet
                .Include(oi => oi.Product)
                .Include(oi => oi.Order)
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();
        }

        public async Task AddOrderItem(OrderItem orderItem)
        {
           await InsertAsync(orderItem);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            Update(orderItem);
        }
    }
}
