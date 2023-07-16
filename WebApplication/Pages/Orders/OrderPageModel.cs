using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace WebApplication.Pages.Orders
{
    [Authorize]
    public class OrderPageModel : PageModel
    {
        protected readonly OrderServices _orderServices;
        protected readonly UserManager<User> _userManager;

        public OrderPageModel(OrderServices orderServices, UserManager<User> userManager)
        {
            _orderServices = orderServices;
            _userManager = userManager;
        }
    }
}
