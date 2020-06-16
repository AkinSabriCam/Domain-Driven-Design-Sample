using Exercise.Application.Contracts.Companies;
using Exercise.Application.Contracts.Companies.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Web.Pages.Companies
{
    public class IndexModel : PageModel
    {
        public IList<CompanyDto> Companies { get; set; } 

        private readonly ICompanyAppService _companyAppService;

        public IndexModel(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }

        public async Task OnGet()
        {
            Companies = await _companyAppService.GetListAsync();
        }
    }

}
