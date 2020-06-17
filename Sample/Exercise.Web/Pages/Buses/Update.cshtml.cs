using AutoMapper;
using Exercise.Application.Contracts.Buses;
using Exercise.Application.Contracts.Buses.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Exercise.Web.Pages.Buses
{
    public class UpdateModel : PageModel
    {
        
        [BindProperty]
        public BusWithDetailsDto Bus { get; set; }
        
        private readonly IBusAppService _busAppService;
        private readonly IMapper _mapper;

        public UpdateModel(IBusAppService busAppService, IMapper mapper)
        {
            _busAppService = busAppService;
            _mapper = mapper;
        }
        public async Task OnGet(Guid id)
        {
            Bus = await _busAppService.GetWithDetailsAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {

           await _busAppService.UpdateAsync(
                _mapper.Map<BusWithDetailsDto, UpdateBusDto>(Bus));


            return RedirectToPage("/Buses/Index");
        }

    }
}
