using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FunBooksAndVideos.Repositories
{
    public class PaymentTypeRepository : BaseRepository<PaymentType, FunBooksAndVideosDbContext>, IPaymentTypeRepository
    {
        private readonly ILogger<UserRepository> _logger;

        public PaymentTypeRepository(
            Lazy<FunBooksAndVideosDbContext> context, 
            ILogger<UserRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<List<PaymentType>> GetPaymentTypes()
        {
            _logger.LogInformation(new EventId(1), $"{nameof(GetPaymentTypes)} - retrieving items from database");

            return await DbSet
                .ToListAsync();
        }

        public async Task<PaymentType?> GetPaymentTypeById(int paymentTypeId)
        {
            _logger.LogInformation(new EventId(2), $"{nameof(GetPaymentTypeById)} - retrieving item for id {paymentTypeId} from database");

            return await GetByIdAsync(paymentTypeId);
        }

        public async Task AddPaymentType(PaymentType paymentType)
        {
            _logger.LogInformation(new EventId(3), $"{nameof(AddPaymentType)} - add item {JsonSerializer.Serialize(paymentType)} to database");

            await InsertAsync(paymentType);
        }

        public void UpdatePaymentType(PaymentType paymentType)
        {
            _logger.LogInformation(new EventId(4), $"{nameof(UpdatePaymentType)} - update item {JsonSerializer.Serialize(paymentType)} to database");

            Update(paymentType);
        }
    }
}
