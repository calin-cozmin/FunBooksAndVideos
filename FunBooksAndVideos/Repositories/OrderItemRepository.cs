using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem, FunBooksAndVideosDbContext>, IOrderItemRepository
    {
        private readonly ILogger<UserRepository> _logger;

        public OrderItemRepository(
            Lazy<FunBooksAndVideosDbContext> context, 
            ILogger<UserRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<List<OrderItem>> GetOrderItems(int orderId)
        {
            _logger.LogInformation(new EventId(1), $"{nameof(GetOrderItems)} - retrieving items from database");

            return await DbSet
                .Include(oi => oi.Product)
                .Include(oi => oi.Order)
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();
        }

        public async Task AddOrderItem(OrderItem orderItem)
        {
            _logger.LogInformation(new EventId(2), $"{nameof(AddOrderItem)} - retrieving item for id {orderItem} from database");

            await InsertAsync(orderItem);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _logger.LogInformation(new EventId(2), $"{nameof(UpdateOrderItem)} - retrieving item for id {orderItem} from database");

            Update(orderItem);
        }
    }
}
