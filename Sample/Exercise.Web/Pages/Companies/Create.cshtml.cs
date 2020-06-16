using AutoMapper;
using Exercise.Application.Contracts.Companies;
using Exercise.Application.Contracts.Companies.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Exercise.Web.Pages.Companies
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateCompanyViewModel Company { get; set; }

        private readonly ICompanyAppService _companyAppService;
        private readonly IMapper _mapper;

        public CreateModel(ICompanyAppService companyAppService, IMapper mapper)
        {
            _companyAppService = companyAppService;
            _mapper = mapper;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var company = _mapper.Map<CreateCompanyViewModel, CreateCompanyDto>(Company);

            await _companyAppService.CreateAsync(company);
            await _companyAppService.EnsureChangesAsync();

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
