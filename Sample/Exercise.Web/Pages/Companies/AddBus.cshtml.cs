using System;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.Application.Contracts.Buses.Dtos;
using Exercise.Application.Contracts.Companies;
using Exercise.Web.Pages.Buses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercise.Web.Pages.Companies
{
    public class AddBusModel : PageModel
    {
        [BindProperty]
        public CreateBusViewModel Bus { get; set; }

        [BindProperty]
        public Guid Id { get; set; }

        private readonly ICompanyAppService _companyAppService;
        private readonly IMapper _mapper;

        public AddBusModel(ICompanyAppService companyAppService, IMapper mapper)
        {
            _companyAppService = companyAppService;
            _mapper = mapper;
        }

        public void OnGet(Guid Id)
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            var bus = _mapper.Map<CreateBusViewModel, AddBusDto>(Bus);
            
            await _companyAppService.AddBusAsync(bus,Id);
            await _companyAppService.EnsureChangesAsync();

            return RedirectToPage("/Companies/Index");
        }
    }

}
