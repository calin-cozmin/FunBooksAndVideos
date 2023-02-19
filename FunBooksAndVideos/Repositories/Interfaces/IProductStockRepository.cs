using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;

namespace FunBooksAndVideos.Repositories.Interfaces
{
    public interface IProductStockRepository : IBaseRepository<ProductStock>
    {
        Task<List<ProductStock>> GetProductStocks();

        Task<ProductStock?> GetProductStockById(int productStockId);

        Task AddProductStock(ProductStock productStockId);

        void UpdateProductStock(ProductStock productStockId);
    }
}
