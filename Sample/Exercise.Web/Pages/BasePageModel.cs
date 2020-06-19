using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercise.Web.Pages
{
    public class BasePageModel : PageModel
    {
        protected readonly IMapper ObjectMapper;

        public BasePageModel(IMapper objectMapper)
        {
            ObjectMapper = objectMapper;
        }
    }
}
