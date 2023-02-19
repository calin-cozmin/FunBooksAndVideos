using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Repositories
{
    public class OrderRepository : BaseRepository<Order, FunBooksAndVideosDbContext>, IOrderRepository
    {
        public OrderRepository(Lazy<FunBooksAndVideosDbContext> context) : base(context)
        {
        }

        public async Task<List<Order>> GetOrder()
        {
            return await DbSet
                .Include(o => o.PaymentType)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Include(o => o.User)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderById(int orderId)
        {
            return await GetByIdAsync(orderId);
        }

        public async Task AddOrder(Order order)
        {
           await InsertAsync(order);
        }

        public void UpdateOrder(Order order)
        {
            Update(order);
        }
    }
}
