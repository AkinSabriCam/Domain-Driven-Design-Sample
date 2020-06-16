using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Domain.Buses
{
    public interface IBusRepository:IBaseRepository<Bus,Guid>
    {
        Task<IList<Bus>> GetBusWithDetailsAsync();

        Task<Bus> GetWithDetailsById(Guid id);
    }
}
