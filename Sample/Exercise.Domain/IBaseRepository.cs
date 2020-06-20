using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Domain
{
    public interface IBaseRepository<TEntity, TId> where TEntity : IBaseEntity<TId> where TId :IEquatable<TId>
    {
        Task<TEntity> GetAsync(TId id);

        Task<IList<TEntity>> GetListAsync();

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(TId id);

        IQueryable<TEntity> GetQueryable();

        Task<bool> EnsureChangesAsync();
    }
}
