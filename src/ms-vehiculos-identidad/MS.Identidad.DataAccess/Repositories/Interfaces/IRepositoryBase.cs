using MS.Identidad.DataAccess.Entities;

namespace MS.Identidad.DataAccess.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<TEntity>> GetAllAsync();
        System.Threading.Tasks.Task<TEntity?> GetByIdAsync(System.Guid id);
        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<TEntity>> FindAsync(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> predicate);
        System.Threading.Tasks.Task AddAsync(TEntity entity);
        void AddRange(System.Collections.Generic.IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(System.Collections.Generic.IEnumerable<TEntity> entities);
        System.Threading.Tasks.Task<bool> ExistsAsync(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> predicate);
    }

}