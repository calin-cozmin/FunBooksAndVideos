using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;

namespace FunBooksAndVideos.Repositories.Interfaces
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
    {
        Task<List<ProductCategory>> GetProductCategories();

        Task<ProductCategory?> GetProductCategoryById(int productCategoryId);

        Task AddProductCategory(ProductCategory productCategory);

        void UpdateProductCategory(ProductCategory productCategory);
    }
}
