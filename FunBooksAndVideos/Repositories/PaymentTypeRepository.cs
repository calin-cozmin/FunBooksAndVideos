using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Repositories
{
    public class PaymentTypeRepository : BaseRepository<PaymentType, FunBooksAndVideosDbContext>, IPaymentTypeRepository
    {
        public PaymentTypeRepository(Lazy<FunBooksAndVideosDbContext> context) : base(context)
        {
        }

        public async Task<List<PaymentType>> GetPaymentTypes()
        {
            return await DbSet
                .ToListAsync();
        }

        public async Task<PaymentType?> GetPaymentTypeById(int paymentTypeId)
        {
            return await GetByIdAsync(paymentTypeId);
        }

        public async Task AddPaymentType(PaymentType paymentType)
        {
           await InsertAsync(paymentType);
        }

        public void UpdatePaymentType(PaymentType paymentType)
        {
            Update(paymentType);
        }
    }
}
