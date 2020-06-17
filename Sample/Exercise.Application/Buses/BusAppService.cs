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
    public class BusAppService : IBusAppService
    {
        private readonly IBusRepository _busRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BusAppService(IBusRepository busRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _busRepository = busRepository;
            _unitOfWork = unitOfWork;
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

        public async Task<IList<BusWithDetailsDto>> GetListWithDetailsAsync(GetListInput input)
        {
            var buses = await _busRepository.GetBusWithDetailsAsync(input.CompanyId, input.Filter);

            return _mapper.Map<IList<Bus>, IList<BusWithDetailsDto>>(buses);
        }

        public async Task<BusWithDetailsDto> GetWithDetailsAsync(Guid id)
        {
            return _mapper.Map<Bus, BusWithDetailsDto>(
                await _busRepository.GetWithDetailsById(id));
        }

        public async Task<CreateBusDto> CreateAsync(CreateBusDto entity)
        {
            using (_unitOfWork)
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
                await _unitOfWork.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<UpdateBusDto> UpdateAsync(UpdateBusDto entity)
        {
            using (_unitOfWork)
            {
                var bus = _mapper.Map<UpdateBusDto, Bus>(entity);
            
                await _busRepository.UpdateAsync(bus);
                await _unitOfWork.SaveChangesAsync();
            }

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            using (_unitOfWork)
            {
                await _busRepository.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
