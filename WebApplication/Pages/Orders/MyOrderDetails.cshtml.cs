using BusinessObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Threading.Tasks;

namespace WebApplication.Pages.Orders
{
    public class MyOrderDetailsModel : OrderPageModel
    {
        public MyOrderDetailsModel(OrderServices orderServices, UserManager<User> userManager) : base(orderServices, userManager)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _orderServices.GetAll().Include(o => o.Product)
          .Include(o => o.User).FirstOrDefaultAsync(m => m.OrderId == id);


            if (Order != null)
            {
                Order.OrderStatus = "CANCELLED";
                await _orderServices.Update(Order);
            }
            return Page();

        }
    }
}
