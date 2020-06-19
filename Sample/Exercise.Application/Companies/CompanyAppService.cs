using AutoMapper;
using Exercise.Application.Contracts.Companies;
using Exercise.Application.Contracts.Companies.Dtos;
using Exercise.Domain.Companies;
using Exercise.EntityFramework.EntityFrameworkCore.UoW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Application.Companies
{
    public class CompanyAppService : BaseAppService, ICompanyAppService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyAppService(
            ICompanyRepository companyRepository,
            IUnitOfWork unitOfWork,
            IMapper objectMapper) : base(objectMapper, unitOfWork)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Company, CompanyDto>(
                await _companyRepository.GetByIdAsync(id));
        }

        public async Task<CompanyWithDetailsDto> GetWithDetailsAsync(Guid id)
        {
            return ObjectMapper.Map<Company, CompanyWithDetailsDto>(
                await _companyRepository.GetWithDetailsById(id));
        }

        public async Task<IList<CompanyDto>> GetListAsync()
        {
            return ObjectMapper.Map<IList<Company>, IList<CompanyDto>>(
                await _companyRepository.GetListAsync());
        }

        public async Task<IList<CompanyWithDetailsDto>> GetListWithDetailsAsync()
        {
            return ObjectMapper.Map<IList<Company>, IList<CompanyWithDetailsDto>>(
                await _companyRepository.GetListWithDetails());
        }

        public async Task<CreateCompanyDto> CreateAsync(CreateCompanyDto entity)
        {
            using (UnitOfWork)
            {
                var company = ObjectMapper.Map<CreateCompanyDto, Company>(entity);

                await _companyRepository.CreateAsync(company);
                await UnitOfWork.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<UpdateCompanyDto> UpdateAsync(UpdateCompanyDto entity)
        {
            using (UnitOfWork)
            {
                var company = ObjectMapper.Map<UpdateCompanyDto, Company>(entity);

                await _companyRepository.UpdateAsync(company);
                await UnitOfWork.SaveChangesAsync();
            }

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            using (UnitOfWork)
            {
                await _companyRepository.DeleteAsync(id);
                await UnitOfWork.SaveChangesAsync();
            }
        }
    }
}
