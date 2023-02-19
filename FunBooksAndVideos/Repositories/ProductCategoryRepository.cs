using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory, FunBooksAndVideosDbContext>, IProductCategoryRepository
    {
        public ProductCategoryRepository(Lazy<FunBooksAndVideosDbContext> context) : base(context)
        {
        }

        public async Task<List<ProductCategory>> GetProductCategories()
        {
            return await DbSet
                .ToListAsync();
        }

        public async Task<ProductCategory?> GetProductCategoryById(int productCategoryId)
        {
            return await GetByIdAsync(productCategoryId);
        }

        public async Task AddProductCategory(ProductCategory productCategory)
        {
           await InsertAsync(productCategory);
        }

        public void UpdateProductCategory(ProductCategory productCategory)
        {
            Update(productCategory);
        }
    }
}
