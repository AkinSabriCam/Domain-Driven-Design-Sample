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
    public class CompanyAppService : ICompanyAppService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyAppService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
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

        public async Task<CreateCompanyDto> CreateAsync(CreateCompanyDto entity)
        {
            using (_unitOfWork)
            {
                var company = _mapper.Map<CreateCompanyDto, Company>(entity);

                await _companyRepository.CreateAsync(company);
                await _unitOfWork.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<UpdateCompanyDto> UpdateAsync(UpdateCompanyDto entity)
        {
            using (_unitOfWork)
            {
                var company = _mapper.Map<UpdateCompanyDto, Company>(entity);

                await _companyRepository.UpdateAsync(company);
                await _unitOfWork.SaveChangesAsync();
            }

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            using (_unitOfWork)
            {
                await _companyRepository.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();
            }
                
        }
    }
}
