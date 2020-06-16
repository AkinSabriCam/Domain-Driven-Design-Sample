using Exercise.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.EntityFrameworkCore
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Role> Roles { get; set; }

        Task<bool> EnsureChangesAsync();

        DbSet<TEntity> SetDbTable<TEntity>() where TEntity : class
            ;
    }
}
