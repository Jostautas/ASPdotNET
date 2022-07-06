using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class NumberModel : PageModel
    {
        private readonly ILogger<NumberModel> _logger;

        public NumberModel(ILogger<NumberModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        
    }
}