using System;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.Application.Contracts.Companies;
using Exercise.Application.Contracts.Companies.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercise.Web.Pages.Companies
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public UpdateCompanyViewModel CompanyModel { get; set; }

        private readonly ICompanyAppService _companyAppService;
        private readonly IMapper _mapper;

        public UpdateModel(ICompanyAppService companyAppService, IMapper mapper)
        {
            _companyAppService = companyAppService;
            _mapper = mapper;
        }

        public async Task OnGet(Guid id)
        {
            var company = await _companyAppService.GetAsync(id);
            CompanyModel = _mapper.Map<CompanyDto, UpdateCompanyViewModel>(company);
        }

        public async Task<IActionResult> OnPost()
        {
            await _companyAppService.UpdateAsync(
               _mapper.Map<UpdateCompanyViewModel, UpdateCompanyDto>(CompanyModel));

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
