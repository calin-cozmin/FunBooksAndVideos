using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FunBooksAndVideos.Repositories
{
    public class ProductStockRepository : BaseRepository<ProductStock, FunBooksAndVideosDbContext>, IProductStockRepository
    {
        private readonly ILogger<ProductStockRepository> _logger;

        public ProductStockRepository(
            Lazy<FunBooksAndVideosDbContext> context, 
            ILogger<ProductStockRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<List<ProductStock>> GetProductStocks()
        {
            _logger.LogInformation(new EventId(1), $"{nameof(GetProductStocks)} - retrieving items from database");

            return await DbSet
                .ToListAsync();
        }

        public async Task<ProductStock?> GetProductStockById(int productStockId)
        {
            _logger.LogInformation(new EventId(2), $"{nameof(GetProductStockById)} - retrieving item for id {productStockId} from database");

            return await GetByIdAsync(productStockId);
        }

        public async Task AddProductStock(ProductStock productStock)
        {
            _logger.LogInformation(new EventId(3), $"{nameof(AddProductStock)} - add item {JsonSerializer.Serialize(productStock)} to database");

            await InsertAsync(productStock);
        }

        public void UpdateProductStock(ProductStock productStock)
        {
            _logger.LogInformation(new EventId(4), $"{nameof(UpdateProductStock)} - update item {JsonSerializer.Serialize(productStock)} to database");

            Update(productStock);
        }
    }
}
