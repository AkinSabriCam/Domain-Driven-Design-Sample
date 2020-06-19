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
            var bus = await _busRepository.GetByIdAsync(id);

            return ObjectMapper.Map<Bus, BusDto>(bus);
        }

        public async Task<IList<BusDto>> GetListAsync()
        {
            var bus = await _busRepository.GetListAsync();

            return ObjectMapper.Map<IList<Bus>, IList<BusDto>>(bus);
        }

        public async Task<IList<BusWithDetailsDto>> GetListWithDetailsAsync(GetListInput input)
        {
            var buses = await _busRepository.GetBusWithDetailsAsync(input.CompanyId, input.Filter);

            return ObjectMapper.Map<IList<Bus>, IList<BusWithDetailsDto>>(buses);
        }

        public async Task<BusWithDetailsDto> GetWithDetailsAsync(Guid id)
        {
            return ObjectMapper.Map<Bus, BusWithDetailsDto>(
                await _busRepository.GetWithDetailsById(id));
        }

        public async Task<CreateBusDto> CreateAsync(CreateBusDto entity)
        {
            using (UnitOfWork)
            {
                var bus = ObjectMapper.Map<CreateBusDto, Bus>(entity);
                bus.AddBusDetail(new BusDetail()
                {
                    Color = entity.Color,
                    Plate = entity.Plate,
                    Km = entity.Km,
                    ProductionDate = entity.ProductionDate
                });

                await _busRepository.CreateAsync(bus);
                await UnitOfWork.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<UpdateBusDto> UpdateAsync(UpdateBusDto entity)
        {
            using (UnitOfWork)
            {
                var bus = ObjectMapper.Map<UpdateBusDto, Bus>(entity);

                await _busRepository.UpdateAsync(bus);
                await UnitOfWork.SaveChangesAsync();
            }

            return entity;
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
