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
        public UpdateBusViewModel BusModel { get; set; }

        private readonly IBusAppService _busAppService;
        private readonly IMapper _mapper;

        public UpdateModel(IBusAppService busAppService, IMapper mapper)
        {
            _busAppService = busAppService;
            _mapper = mapper;
        }
        public async Task OnGet(Guid id)
        {
            var bus = await _busAppService.GetWithDetailsAsync(id);
            BusModel = _mapper.Map<BusWithDetailsDto, UpdateBusViewModel>(bus);
        }

        public async Task<IActionResult> OnPost()
        {

            await _busAppService.UpdateAsync(
                 _mapper.Map<UpdateBusViewModel, UpdateBusDto>(BusModel));


            return RedirectToPage("/Buses/Index");
        }
    }

    public class UpdateBusViewModel
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }

        public string CompanyName { get; set; }

        public int SeatCount { get; set; }

        public int Km { get; set; }

        public string Mark { get; set; }

        public string ExpeditionNumber { get; set; }

        public string Route { get; set; }

        public string Color { get; set; }

        public string Plate { get; set; }

        public DateTime ProductionDate { get; set; }
    }
}
