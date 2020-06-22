using AutoMapper;
using Exercise.Application.Contracts.Buses;
using Exercise.Application.Contracts.Buses.Dtos;
using Exercise.Domain.Buses;
using Exercise.EntityFramework.EntityFrameworkCore.UoW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Application.Buses
{
    public class BusAppService : BaseAppService, IBusAppService
    {
        private readonly IBusRepository _busRepository;

        public BusAppService(
            IBusRepository busRepository,
            IUnitOfWork unitOfWork,
            IMapper objecTMapper) : base(objecTMapper, unitOfWork)
        {
            _busRepository = busRepository;
        }

        public async Task<BusDto> GetAsync(Guid id)
        {
            var bus = await _busRepository.GetAsync(id);

            return ObjectMapper.Map<Bus, BusDto>(bus);
        }

        public async Task<IList<BusDto>> GetListAsync()
        {
            var bus = await _busRepository.GetListAsync();

            return ObjectMapper.Map<IList<Bus>, IList<BusDto>>(bus);
        }

        public async Task<IList<BusWithDetailsDto>> GetListWithDetailsAsync(GetListInput input)
        {
            var buses = await _busRepository.GetListWithDetailsAsync(input.CompanyId, input.Filter);

            return ObjectMapper.Map<IList<Bus>, IList<BusWithDetailsDto>>(buses);
        }

        public async Task<BusWithDetailsDto> GetWithDetailsAsync(Guid id)
        {
            return ObjectMapper.Map<Bus, BusWithDetailsDto>(
                await _busRepository.GetWithDetailsAsync(id));
        }

        public async Task<BusDto> CreateAsync(CreateBusDto createBusDto)
        {
            using (UnitOfWork)
            {
                var bus = new Bus(
                    createBusDto.Mark,
                    createBusDto.ExpeditionNumber,
                    createBusDto.SeatCount,
                    createBusDto.Route,
                    createBusDto.CompanyId,Guid.NewGuid());

                bus.AddBusDetail(new BusDetail()
                {
                    Color = createBusDto.Color,
                    Plate = createBusDto.Plate,
                    Km = createBusDto.Km,
                    ProductionDate = createBusDto.ProductionDate
                });

                await _busRepository.CreateAsync(bus);
                await UnitOfWork.SaveChangesAsync();

                return ObjectMapper.Map<Bus, BusDto>(bus);
            }

        }

        public async Task<BusDto> UpdateAsync(UpdateBusDto updateBusDto)
        {
            using (UnitOfWork)
            {
                var bus = await _busRepository.GetAsync(updateBusDto.Id);

                bus.SetSeatCount(updateBusDto.SeatCount);
                bus.SetRoute(updateBusDto.Route);
                bus.SetMark(updateBusDto.Mark);
                bus.SetExpeditionNumber(updateBusDto.ExpeditionNumber);

                await _busRepository.UpdateAsync(bus);
                await UnitOfWork.SaveChangesAsync();

                return ObjectMapper.Map<Bus, BusDto>(bus);    
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (UnitOfWork)
            {
                await _busRepository.DeleteAsync(id);
                await UnitOfWork.SaveChangesAsync();
            }
        }
    }
}
