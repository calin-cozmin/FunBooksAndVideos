using FunBooksAndVideos.Models;

namespace FunBooksAndVideos.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAllProducts();

        Task<ProductModel> GetProductById(int productId);
    }
}
