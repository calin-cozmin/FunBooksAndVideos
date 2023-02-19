using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Repositories
{
    public class ProductStockRepository : BaseRepository<ProductStock, FunBooksAndVideosDbContext>, IProductStockRepository
    {
        public ProductStockRepository(Lazy<FunBooksAndVideosDbContext> context) : base(context)
        {
        }

        public async Task<List<ProductStock>> GetProductStocks()
        {
            return await DbSet
                .ToListAsync();
        }

        public async Task<ProductStock?> GetProductStockById(int productStockId)
        {
            return await GetByIdAsync(productStockId);
        }

        public async Task AddProductStock(ProductStock productStock)
        {
           await InsertAsync(productStock);
        }

        public void UpdateProductStock(ProductStock productStock)
        {
            Update(productStock);
        }
    }
}
