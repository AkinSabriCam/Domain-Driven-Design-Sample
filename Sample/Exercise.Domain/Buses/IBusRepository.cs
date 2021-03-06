﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Domain.Buses
{
    public interface IBusRepository : IBaseRepository<Bus, Guid>
    {
        Task<Bus> GetWithDetailsAsync(Guid id);

        Task<IList<Bus>> GetListWithDetailsAsync(Guid? companyId, string filter = null);
    }
}
