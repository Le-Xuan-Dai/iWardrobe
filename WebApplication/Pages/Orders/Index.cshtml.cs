using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using Services;
using Microsoft.AspNetCore.Identity;
using WebApplication.Pages.Orders;
using Microsoft.AspNetCore.Authorization;
using Services.Interfaces;

namespace WebApplication.Pages.Shop.Orders
{
    [Authorize(Roles = "Supplier")]
    public class IndexModel : OrderPageModel
    {
        public IndexModel(IOrderServices orderServices, UserManager<User> userManager) : base(orderServices, userManager)
        {
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            string currentUserId = _userManager.GetUserId(User);
            Order = await _orderServices.GetAll().Include(o => o.Product)
               .Include(o => o.User).Where(o => o.Product.UserId.Equals(currentUserId)).ToListAsync();
        }
    }
}
