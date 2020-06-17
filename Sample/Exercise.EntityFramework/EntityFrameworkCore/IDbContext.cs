using Exercise.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.EntityFrameworkCore
{
    public interface IDbContext : IDisposable
    {
        DbSet<User> Users { get; set; }

        DbSet<Role> Roles { get; set; }

        Task<bool> EnsureChangesAsync();

        DbSet<TEntity> SetDbTable<TEntity>() where TEntity : class;
    }
}
