using Exercise.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.EntityFrameworkCore
{
    public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
                            where TEntity : class, IBaseEntity<TId>, new()
                            where TId : IEquatable<TId>
    {

        private readonly IDbContext _dbContext;
        private DbSet<TEntity> _dbTable { get; set; }

        public BaseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbTable = _dbContext.SetDbTable<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbTable.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(TId id)
        {
            var entity = await _dbTable.FindAsync(id);
            _dbTable.Remove(entity);
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await _dbTable.FindAsync(id);
        }

        public async Task<IList<TEntity>> GetListAsync()
        {
            return await _dbTable.ToListAsync();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dbTable.AsQueryable();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbTable.Update(entity);
            return await Task.FromResult(entity);
        }

        public async Task<bool> EnsureChangesAsync()
        {
            return await _dbContext.EnsureChangesAsync();
        }
    }
}
