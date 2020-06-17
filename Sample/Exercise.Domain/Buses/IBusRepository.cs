using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Domain.Buses
{
    public interface IBusRepository:IBaseRepository<Bus,Guid>
    {
        Task<IList<Bus>> GetBusWithDetailsAsync(Guid? companyId, string filter = null);

        Task<Bus> GetWithDetailsById(Guid id);
    }
}
