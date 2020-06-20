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
                await _companyRepository.GetAsync(id));
        }

        public async Task<CompanyWithDetailsDto> GetWithDetailsAsync(Guid id)
        {
            return ObjectMapper.Map<Company, CompanyWithDetailsDto>(
                await _companyRepository.GetWithDetailsAsync(id));
        }

        public async Task<IList<CompanyDto>> GetListAsync()
        {
            return ObjectMapper.Map<IList<Company>, IList<CompanyDto>>(
                await _companyRepository.GetListAsync());
        }

        public async Task<IList<CompanyWithDetailsDto>> GetListWithDetailsAsync()
        {
            return ObjectMapper.Map<IList<Company>, IList<CompanyWithDetailsDto>>(
                await _companyRepository.GetListWithDetailsAsync());
        }

        public async Task<CompanyDto> CreateAsync(CreateCompanyDto createCompanyDto)
        {
            using (UnitOfWork)
            {
                var company = new Company(
                    createCompanyDto.CompanyName, 
                    createCompanyDto.HeadQuarters, 
                    createCompanyDto.FoundationDate, 
                    createCompanyDto.EmployersCount,
                    Guid.NewGuid());

                await _companyRepository.CreateAsync(company);
                await UnitOfWork.SaveChangesAsync();

                return ObjectMapper.Map<Company, CompanyDto>(company);    
            }
        }

        public async Task<CompanyDto> UpdateAsync(UpdateCompanyDto updateCompanyDto)
        {
            using (UnitOfWork)
            {
                var company = await _companyRepository.GetAsync(updateCompanyDto.Id);

                company.SetCompanyName(updateCompanyDto.CompanyName);
                company.SetEmployersCount(updateCompanyDto.EmployersCount);
                company.SetFoundationDate(updateCompanyDto.FoundationDate);
                company.SetHeadQuarters(updateCompanyDto.HeadQuarters);

                await _companyRepository.UpdateAsync(company);
                await UnitOfWork.SaveChangesAsync();

                return ObjectMapper.Map<Company, CompanyDto>(company);
            }
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
