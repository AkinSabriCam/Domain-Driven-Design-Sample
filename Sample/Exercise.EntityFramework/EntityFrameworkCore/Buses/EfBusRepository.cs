using Exercise.Domain.Buses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var buses = GetQueryable();
            buses = buses.Include(x => x.BusDetail);

            return await buses.ToListAsync();
        }

        public async Task<Bus> GetWithDetailsById(Guid id)
        {
            var buses = GetQueryable();
            buses = buses.Include(x => x.BusDetail);

            return await buses.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
