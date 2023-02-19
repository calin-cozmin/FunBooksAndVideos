using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;

namespace FunBooksAndVideos.Repositories.Interfaces
{
    public interface IPaymentTypeRepository : IBaseRepository<PaymentType>
    {
        Task<List<PaymentType>> GetPaymentTypes();

        Task<PaymentType?> GetPaymentTypeById(int paymentTypeId);

        Task AddPaymentType(PaymentType paymentType);

        void UpdatePaymentType(PaymentType paymentType);
    }
}
