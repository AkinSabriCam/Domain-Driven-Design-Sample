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

        public async Task<IList<Bus>> GetBusWithDetailsAsync(Guid? companyId, string filter = null)
        {
            var entities = GetAllBusDetails();

            if (!string.IsNullOrEmpty(filter))
            {
                entities = entities.Where(x => x.Mark.Contains(filter) ||
                                 x.Route.Contains(filter) ||
                                 x.ExpeditionNumber.Contains(filter));
            }

            if (companyId != null)
            {
                entities = entities
                    .Where(x => x.CompanyId == companyId);
            }

            return await entities.ToListAsync();
        }

        public async Task<Bus> GetWithDetailsById(Guid id)
        {
            return await GetAllBusDetails().FirstOrDefaultAsync(x => x.Id == id);
        }

        private IQueryable<Bus> GetAllBusDetails()
        {
            var buses = GetQueryable();
            buses = buses.Include(x => x.BusDetail);
            buses = buses.Include(x => x.Company);
            return buses;
        }
    }
}
