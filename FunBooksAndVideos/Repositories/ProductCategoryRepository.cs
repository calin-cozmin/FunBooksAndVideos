using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FunBooksAndVideos.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory, FunBooksAndVideosDbContext>, IProductCategoryRepository
    {
        private readonly ILogger<UserRepository> _logger;

        public ProductCategoryRepository(
            Lazy<FunBooksAndVideosDbContext> context, 
            ILogger<UserRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<List<ProductCategory>> GetProductCategories()
        {
            _logger.LogInformation(new EventId(1), $"{nameof(GetProductCategories)} - retrieving items from database");

            return await DbSet
                .ToListAsync();
        }

        public async Task<ProductCategory?> GetProductCategoryById(int productCategoryId)
        {
            _logger.LogInformation(new EventId(2), $"{nameof(GetProductCategoryById)} - retrieving item for id {productCategoryId} from database");

            return await GetByIdAsync(productCategoryId);
        }

        public async Task AddProductCategory(ProductCategory productCategory)
        {
            _logger.LogInformation(new EventId(3), $"{nameof(AddProductCategory)} - add item {JsonSerializer.Serialize(productCategory)} to database");

            await InsertAsync(productCategory);
        }

        public void UpdateProductCategory(ProductCategory productCategory)
        {
            _logger.LogInformation(new EventId(4), $"{nameof(UpdateProductCategory)} - update item {JsonSerializer.Serialize(productCategory)} to database");

            Update(productCategory);
        }
    }
}
