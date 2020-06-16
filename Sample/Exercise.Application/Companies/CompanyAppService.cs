using AutoMapper;
using Exercise.Application.Contracts.Buses.Dtos;
using Exercise.Application.Contracts.Companies;
using Exercise.Application.Contracts.Companies.Dtos;
using Exercise.Domain.Buses;
using Exercise.Domain.Companies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Application.Companies
{
    public class CompanyAppService : ICompanyAppService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IBusRepository _busRepository;

        private readonly IMapper _mapper;

        public CompanyAppService(ICompanyRepository companyRepository, IMapper mapper, IBusRepository busRepository)
        {
            _companyRepository = companyRepository;
            _busRepository = busRepository;
            _mapper = mapper;
        }

        public async Task<CompanyDto> GetAsync(Guid id)
        {
            return _mapper.Map<Company, CompanyDto>(
                await _companyRepository.GetByIdAsync(id));
        }

        public async Task<CompanyWithDetailsDto> GetWithDetailsAsync(Guid id)
        {
            return _mapper.Map<Company, CompanyWithDetailsDto>(
                await _companyRepository.GetWithDetailsById(id));
        }

        public async Task<IList<CompanyDto>> GetListAsync()
        {
            return _mapper.Map<IList<Company>, IList<CompanyDto>>(
                await _companyRepository.GetListAsync());
        }

        public async Task<IList<CompanyWithDetailsDto>> GetListWithDetailsAsync()
        {
            return _mapper.Map<IList<Company>, IList<CompanyWithDetailsDto>>(
                await _companyRepository.GetListWithDetails());
        }

        public async Task<AddBusDto> AddBusAsync(AddBusDto entity, Guid companyId)
        {
            var company = await _companyRepository.GetByIdAsync(companyId);
            var bus = _mapper.Map<AddBusDto, Bus>(entity);

            bus.AddBusDetail(new BusDetail()
            {
                Color = entity.Color,
                Km = entity.Km,
                Plate = entity.Plate,
                ReleaseDate = entity.ReleaseDate
            });

            await _busRepository.CreateAsync(bus);
            
            company.AddBus(bus);
            return entity;
        }

        public async Task<CreateCompanyDto> CreateAsync(CreateCompanyDto entity)
        {
            var company = _mapper.Map<CreateCompanyDto, Company>(entity);
            await _companyRepository.CreateAsync(company);

            return entity;
        }

        public async Task<UpdateCompanyDto> UpdateAsync(UpdateCompanyDto entity)
        {
            var company = _mapper.Map<UpdateCompanyDto, Company>(entity);
            await _companyRepository.UpdateAsync(company);

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _companyRepository.DeleteAsync(id);
        }

        public async Task<bool> EnsureChangesAsync()
        {
            return await _companyRepository.EnsureChangesAsync();
        }

    }
}
