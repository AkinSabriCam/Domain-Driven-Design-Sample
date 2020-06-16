using AutoMapper;
using Exercise.Application.Contracts.Buses;
using Exercise.Application.Contracts.Buses.Dtos;
using Exercise.Domain.Buses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Application.Buses
{
    public class BusAppService : IBusAppService
    {
        private readonly IBusRepository _busRepository;
        private readonly IMapper _mapper;

        public BusAppService(IBusRepository busRepository, IMapper mapper)
        {
            _busRepository = busRepository;
            _mapper = mapper;
        }

        public async Task<BusDto> GetAsync(Guid id)
        {
            var bus = await _busRepository.GetByIdAsync(id);

            return _mapper.Map<Bus, BusDto>(bus);
        }

        public async Task<IList<BusDto>> GetListAsync()
        {
            var bus = await _busRepository.GetListAsync();

            return _mapper.Map<IList<Bus>, IList<BusDto>>(bus);

        }

        public async Task<IList<BusWithDetailsDto>> GetListWithDetailsAsync()
        {
            var buses = await _busRepository.GetBusWithDetailsAsync();

            return _mapper.Map<IList<Bus>, IList<BusWithDetailsDto>>(buses);
        }

        public async Task<BusWithDetailsDto> GetWithDetailsAsync(Guid id)
        {
            return _mapper.Map<Bus, BusWithDetailsDto>(
                await _busRepository.GetWithDetailsById(id));
        }

        public async Task<CreateBusDto> CreateAsync(CreateBusDto entity)
        {
            var bus = _mapper.Map<CreateBusDto, Bus>(entity);
            bus.AddBusDetail(new BusDetail()
            {
                Color = entity.Color,
                Plate = entity.Plate,
                Km = entity.Km,
                ReleaseDate = entity.ReleaseDate
            });

            await _busRepository.CreateAsync(bus);

            return entity;
        }

        public async Task<UpdateBusDto> UpdateAsync(UpdateBusDto entity)
        {
            var bus = _mapper.Map<UpdateBusDto, Bus>(entity);
            await _busRepository.UpdateAsync(bus);

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _busRepository.DeleteAsync(id);
        }

        public async Task<bool> EnsureChangesAsync()
        {
            return await _busRepository.EnsureChangesAsync();
        }

    }
}
