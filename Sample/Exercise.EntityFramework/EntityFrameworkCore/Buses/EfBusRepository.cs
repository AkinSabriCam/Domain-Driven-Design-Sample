using Exercise.Domain.Buses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.EntityFrameworkCore.Buses
{
    public class EfBusRepository : BaseRepository<Bus, Guid>, IBusRepository
    {
        public EfBusRepository(IDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<IList<Bus>> GetBusWithDetailsAsync()
        {
            return await GetAllBusDetailsAsync().ToListAsync();
        }

        public async Task<Bus> GetWithDetailsById(Guid id)
        {
            return await GetAllBusDetailsAsync().FirstOrDefaultAsync(x => x.Id == id);
        }

        private IQueryable<Bus> GetAllBusDetailsAsync()
        {
            var buses = GetQueryable();
            buses = buses.Include(x => x.BusDetail);
            buses = buses.Include(x => x.Company);
            return buses;
        }
    }
}
