using AutoMapper;
using Exercise.Application.Contracts.Companies;
using Exercise.Application.Contracts.Companies.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Exercise.Web.Pages.Companies
{
    public class CreateModel : BasePageModel
    {
        [BindProperty]
        public CreateCompanyViewModel Company { get; set; }

        private readonly ICompanyAppService _companyAppService;

        public CreateModel(ICompanyAppService companyAppService, IMapper objectMapper) : base(objectMapper)
        {
            _companyAppService = companyAppService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var company = ObjectMapper.Map<CreateCompanyViewModel, CreateCompanyDto>(Company);
            await _companyAppService.CreateAsync(company);

            return RedirectToPage("/Companies/Index");
        }

    }

    public class CreateCompanyViewModel
    {
        public string CompanyName { get; set; }

        public string HeadQuarters { get; set; }

        public DateTime FoundationDate { get; set; }

        public int EmployersCount { get; set; }
    }
}
