using BusinessObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Pages.Orders
{
    public class MyOrderModel : OrderPageModel
    {
        public MyOrderModel(IOrderServices orderServices, UserManager<User> userManager) : base(orderServices, userManager)
        {
        }

        public IList<Order> Order { get; set; }

        public async Task OnGetAsync()
        {
            string currentUserId = _userManager.GetUserId(User);
            Order = await _orderServices.GetAll().Include(o => o.Product)
         .Include(o => o.User).Where(o => o.UserId.Equals(currentUserId)).ToListAsync();
        }
    }
}
