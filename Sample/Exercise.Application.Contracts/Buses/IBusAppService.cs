using Exercise.Application.Contracts.Buses.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Application.Contracts.Buses
{
    public interface IBusAppService
    {
        Task<BusDto> GetAsync(Guid id);

        Task<BusWithDetailsDto> GetWithDetailsAsync(Guid id);

        Task<IList<BusDto>> GetListAsync();

        Task<IList<BusWithDetailsDto>> GetListWithDetailsAsync(GetListInput input);

        Task<BusDto> CreateAsync(CreateBusDto createBusDto);

        Task<BusDto> UpdateAsync(UpdateBusDto updateBusDto);

        Task DeleteAsync(Guid id);
    }
}
