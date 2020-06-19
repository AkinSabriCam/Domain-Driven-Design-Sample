using System;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.Application.Contracts.Companies;
using Exercise.Application.Contracts.Companies.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Exercise.Web.Pages.Companies
{
    public class UpdateModel : BasePageModel
    {
        [BindProperty]
        public UpdateCompanyViewModel CompanyModel { get; set; }

        private readonly ICompanyAppService _companyAppService;

        public UpdateModel(ICompanyAppService companyAppService, IMapper objectMapper) : base(objectMapper)
        {
            _companyAppService = companyAppService;
        }

        public async Task OnGet(Guid id)
        {
            var company = await _companyAppService.GetAsync(id);
            CompanyModel = ObjectMapper.Map<CompanyDto, UpdateCompanyViewModel>(company);
        }

        public async Task<IActionResult> OnPost()
        {
            await _companyAppService.UpdateAsync(
               ObjectMapper.Map<UpdateCompanyViewModel, UpdateCompanyDto>(CompanyModel));

            return RedirectToPage("Index");
        }
    }

    public class UpdateCompanyViewModel
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string HeadQuarters { get; set; }

        public DateTime FoundationDate { get; set; }

        public int EmployersCount { get; set; }

    }
}
