using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FunBooksAndVideos.Repositories
{
    public class ProductRepository : BaseRepository<Product, FunBooksAndVideosDbContext>, IProductRepository
    {
        private readonly ILogger<UserRepository> _logger;

        public ProductRepository(
            Lazy<FunBooksAndVideosDbContext> context, 
            ILogger<UserRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<List<Product>> GeProducts()
        {
            _logger.LogInformation(new EventId(1), $"{nameof(GeProducts)} - retrieving items from database");

            return await DbSet
                .Include(p => p.ProductStock)
                .Include(p => p.ProductCategory)
                .ToListAsync();
        }

        public async Task<Product?> GetProductById(int productId)
        {
            _logger.LogInformation(new EventId(2), $"{nameof(GetProductById)} - retrieving item for id {productId} from database");

            return await GetByIdAsync(productId);
        }

        public async Task AddProduct(Product product)
        {
            _logger.LogInformation(new EventId(3), $"{nameof(AddProduct)} - add item {JsonSerializer.Serialize(product)} to database");

            await InsertAsync(product);
        }

        public void UpdateProduct(Product product)
        {
            _logger.LogInformation(new EventId(4), $"{nameof(UpdateProduct)} - update item {JsonSerializer.Serialize(product)} to database");

            Update(product);
        }
    }
}
