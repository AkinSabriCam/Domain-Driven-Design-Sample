using System;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.Application.Contracts.Buses;
using Exercise.Application.Contracts.Buses.Dtos;
using Exercise.Web.Pages.Buses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercise.Web.Pages.Companies
{
    public class AddBusModel : BasePageModel
    {
        [BindProperty]
        public CreateBusViewModel Bus { get; set; }

        [BindProperty]
        public Guid Id { get; set; }

        private readonly IBusAppService _busAppService;

        public AddBusModel(IBusAppService busAppService, IMapper objectMapper) : base(objectMapper)
        {
            _busAppService = busAppService;
        }

        public void OnGet(Guid Id)
        {

        }

        public async Task<IActionResult> OnPost()
        {
            var bus = ObjectMapper.Map<CreateBusViewModel, CreateBusDto>(Bus);
            bus.CompanyId = Id;

            await _busAppService.CreateAsync(bus);

            return RedirectToPage("/Companies/Index");
        }
    }

}
