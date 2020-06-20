using Exercise.Application.Contracts.Buses.Dtos;
using Exercise.Application.Contracts.Companies.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Application.Contracts.Companies
{
    public interface ICompanyAppService
    {
        Task<CompanyDto> GetAsync(Guid id);

        Task<CompanyWithDetailsDto> GetWithDetailsAsync(Guid id);

        Task<IList<CompanyDto>> GetListAsync();

        Task<IList<CompanyWithDetailsDto>> GetListWithDetailsAsync();

        Task<CompanyDto> CreateAsync(CreateCompanyDto entity);

        Task<CompanyDto> UpdateAsync(UpdateCompanyDto entity);

        Task DeleteAsync(Guid id);
    }
}
