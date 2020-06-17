using Exercise.Application.Contracts.Buses;
using Exercise.Application.Contracts.Buses.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Web.Pages.Buses
{
    public class IndexModel : PageModel
    {
        private readonly IBusAppService _busAppService;

        public IList<BusWithDetailsDto> BusList { get; set; }  

        public IndexModel(IBusAppService busAppService)
        {
            _busAppService = busAppService;
        }
        public async Task OnGet()
        {
            BusList = await _busAppService.GetListWithDetailsAsync();
        }

        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            await _busAppService.DeleteAsync(id);
            await _busAppService.EnsureChangesAsync();
            
            return RedirectToPage("Index");
        }
    }
}
