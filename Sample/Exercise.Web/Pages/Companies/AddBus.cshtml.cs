using System;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.Application.Contracts.Buses;
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

        private readonly IBusAppService _busAppService;
        private readonly IMapper _mapper;

        public AddBusModel(IBusAppService busAppService, IMapper mapper)
        {
            _busAppService = busAppService;
            _mapper = mapper;
        }

        public void OnGet(Guid Id)
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            var bus = _mapper.Map<CreateBusViewModel, CreateBusDto>(Bus);
            bus.CompanyId = Id;

            await _busAppService.CreateAsync(bus);

            return RedirectToPage("/Companies/Index");
        }
    }

}
