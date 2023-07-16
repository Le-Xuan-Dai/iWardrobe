using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages.Payment
{
    [Authorize]
    public class PaymentSuccessModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
