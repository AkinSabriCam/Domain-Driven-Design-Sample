using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exercise.Application.Contracts.Buses;
using Exercise.Application.Contracts.Buses.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercise.Web.Pages.Companies
{
    public class CompanyBussesModel : PageModel
    {
        private readonly IBusAppService _busAppService;

        public IList<BusWithDetailsDto> BusList { get; set; }

        public CompanyBussesModel(IBusAppService busAppService)
        {
            _busAppService = busAppService;
        }

        public async Task OnGet(Guid Id)
        {
            BusList = await _busAppService.GetListWithDetailsAsync(new GetListInput { CompanyId = Id });
        }
    }
}
