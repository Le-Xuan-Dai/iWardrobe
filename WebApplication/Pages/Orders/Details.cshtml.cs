using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Services;
using WebApplication.Pages.Orders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Services.Interfaces;

namespace WebApplication.Pages.Shop.Orders
{
    [Authorize(Roles = "Supplier")]
    public class DetailsModel : OrderPageModel
    {
        public DetailsModel(IOrderServices orderServices, UserManager<User> userManager) : base(orderServices, userManager)
        {
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _orderServices.GetAll().Include(o => o.Product)
                .Include(o => o.User).FirstOrDefaultAsync(m => m.OrderId == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string orderStatus)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _orderServices.GetAll().Include(o => o.Product)
          .Include(o => o.User).FirstOrDefaultAsync(m => m.OrderId == id);


            if (Order != null)
            {
                Order.OrderStatus = orderStatus;
                await _orderServices.Update(Order);
            }
            return Page();

        }
    }
}
