using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.Application.Contracts.Buses;
using Exercise.Application.Contracts.Buses.Dtos;
using Exercise.Application.Contracts.Companies;
using Exercise.Application.Contracts.Companies.Dtos;
using Exercise.Domain.Companies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercise.Web.Pages.Buses
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateBusViewModel Bus { get; set; }

        public IList<CompanyDto> Companies { get; set; }

        private readonly IBusAppService _busAppService;
        private readonly ICompanyAppService _companyAppService;
        private readonly IMapper _mapper;

        public CreateModel(
            IBusAppService busAppService,
            IMapper mapper,
            ICompanyAppService companyAppService)
        {
            _busAppService = busAppService;
            _mapper = mapper;
            _companyAppService = companyAppService;
        }
        public async Task OnGet()
        {
            Companies = await _companyAppService.GetListAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            var busDto = _mapper.Map<CreateBusViewModel, CreateBusDto>(Bus);
            await _busAppService.CreateAsync(busDto);

            return RedirectToPage("/Buses/Index");
        }
    }

    public class CreateBusViewModel
    {
        public Guid CompanyId { get; set; }

        public int SeatCount { get; set; }

        public int Km { get; set; }

        public string Mark { get; set; }

        public string ExpeditionNumber { get; set; }

        public string Route { get; set; }

        public string Color { get; set; }

        public string Plate { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
