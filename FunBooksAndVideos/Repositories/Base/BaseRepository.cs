using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Repositories.Base
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity> 
        where TEntity : class 
        where TContext : DbContext
    {
        private readonly Lazy<TContext> _dBcontext;
        protected TContext DbContext => _dBcontext.Value;

        protected DbSet<TEntity> DbSet => _dBcontext.Value.Set<TEntity>();

        public BaseRepository(Lazy<TContext> dBcontext)
        {
            _dBcontext = dBcontext;
        }

        public async Task<IList<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy, 
            bool asNoTracking = false,
            int? take = null)
        {
            IQueryable<TEntity> query = GetQuery(filter, orderBy);

            if (asNoTracking)
                query = query.AsNoTracking();

            if (take.HasValue)
                query = query.Take(take.Value);

            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<TEntity?> GetFirstOrDefaultAsync(
            Expression<Func<TEntity, bool>>? filter,
            bool asNoTracking = false)
        {
            IQueryable<TEntity> query = GetQuery(filter, null);

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> IsAnyAsync(Expression<Func<TEntity, bool>>? filter)
        {
            IQueryable<TEntity> query = GetQuery(filter, null);

            return await query.AnyAsync();
        }

        public async Task InsertAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public Task SaveAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        private IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>>? filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy)
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }
    }
}
