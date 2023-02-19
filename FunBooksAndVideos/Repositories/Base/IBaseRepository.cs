using System.Linq.Expressions;

namespace FunBooksAndVideos.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy,
            bool asNoTracking = false,
            int? take = null);

        Task<TEntity?> GetByIdAsync(object id);

        Task<TEntity?> GetFirstOrDefaultAsync(
            Expression<Func<TEntity, bool>>? filter,
            bool asNoTracking = false);

        Task<bool> IsAnyAsync(Expression<Func<TEntity, bool>>? filter);

        Task InsertAsync(TEntity entity);

        Task InsertRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);

        Task SaveAsync();
    }
}
