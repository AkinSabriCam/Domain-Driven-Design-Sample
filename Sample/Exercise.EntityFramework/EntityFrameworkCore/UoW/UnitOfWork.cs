using System;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.EntityFrameworkCore.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;
        public bool _disposed = false;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.EnsureChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && _dbContext != null)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }

    }
}
