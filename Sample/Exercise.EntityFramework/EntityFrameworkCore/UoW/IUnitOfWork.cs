using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.EntityFrameworkCore.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
    }
}
