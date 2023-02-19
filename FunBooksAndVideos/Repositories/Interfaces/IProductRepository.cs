using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;

namespace FunBooksAndVideos.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<Product>> GeProducts();

        Task<Product?> GetProductById(int productId);

        Task AddProduct(Product product);

        void UpdateProduct(Product product);
    }
}
