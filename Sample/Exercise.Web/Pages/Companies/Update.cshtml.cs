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
        public CompanyDto Company { get; set; }

        private readonly ICompanyAppService _companyAppService;
        private readonly IMapper _mapper;


        public UpdateModel(ICompanyAppService companyAppService, IMapper mapper)
        {
            _companyAppService = companyAppService;
            _mapper = mapper;
        }


        public async Task OnGet(Guid id)
        {
            Company = await _companyAppService.GetAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            await _companyAppService.UpdateAsync(
               _mapper.Map<CompanyDto, UpdateCompanyDto>(Company));

            await _companyAppService.EnsureChangesAsync();

            return RedirectToPage("Index");
        }
    }

}
