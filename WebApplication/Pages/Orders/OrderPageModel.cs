using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Services.Interfaces;

namespace WebApplication.Pages.Orders
{
    [Authorize]
    public class OrderPageModel : PageModel
    {
        protected readonly IOrderServices _orderServices;
        protected readonly UserManager<User> _userManager;

        public OrderPageModel(IOrderServices orderServices, UserManager<User> userManager)
        {
            _orderServices = orderServices;
            _userManager = userManager;
        }
    }
}
