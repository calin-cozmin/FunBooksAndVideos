using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FunBooksAndVideos.Repositories
{
    public class OrderRepository : BaseRepository<Order, FunBooksAndVideosDbContext>, IOrderRepository
    {
        private readonly ILogger<UserRepository> _logger;

        public OrderRepository(
            Lazy<FunBooksAndVideosDbContext> context, 
            ILogger<UserRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<List<Order>> GetOrders()
        {
            _logger.LogInformation(new EventId(1), $"{nameof(GetOrders)} - retrieving items from database");

            return await DbSet
                .Include(o => o.PaymentType)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Include(o => o.User)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderById(int orderId)
        {
            _logger.LogInformation(new EventId(2), $"{nameof(GetOrderById)} - retrieving item for id {orderId} from database");

            return await GetByIdAsync(orderId);
        }

        public async Task AddOrder(Order order)
        {
            _logger.LogInformation(new EventId(3), $"{nameof(AddOrder)} - add item {JsonSerializer.Serialize(order)} to database");

            await InsertAsync(order);
        }

        public void UpdateOrder(Order order)
        {
            _logger.LogInformation(new EventId(4), $"{nameof(UpdateOrder)} - update item {JsonSerializer.Serialize(order)} to database");

            Update(order);
        }
    }
}
