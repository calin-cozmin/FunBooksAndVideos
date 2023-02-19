using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Repositories
{
    public class ProductRepository : BaseRepository<Product, FunBooksAndVideosDbContext>, IProductRepository
    {
        public ProductRepository(Lazy<FunBooksAndVideosDbContext> context) : base(context)
        {
        }

        public async Task<List<Product>> GeProducts()
        {
            return await DbSet
                .Include(p => p.ProductStock)
                .Include(p => p.ProductCategory)
                .ToListAsync();
        }

        public async Task<Product?> GetProductById(int productId)
        {
            return await GetByIdAsync(productId);
        }

        public async Task AddProduct(Product product)
        {
           await InsertAsync(product);
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
        }
    }
}
