using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Pages.Cart_Payment
{
    public class PaymentModel : PageModel
    {
        private readonly CartDetailServices _cartDetailServices;
        private readonly UserServices _userServices;
        private readonly ProductServices _productServices;
        private readonly OrderServices _orderServices;
        public PaymentModel (CartDetailServices cartDetailServices , UserServices userServices, ProductServices productServices)
        {
            _cartDetailServices = cartDetailServices;
            _userServices = userServices;
            _productServices = productServices;
        }
        [BindProperty]
        public Order Order { get; set; }
        public CartDetail cartDetail { get; set; }

        public List<Voucher> Voucher { get; set; }

        public Product productPayment { get; set; }

        public Voucher voucher { get; set; }
        public async Task<IActionResult> OnGet(CartDetail? _cartDetail)
        {
            cartDetail = _cartDetail; 
            return Page();
        }

        public async Task<IActionResult> OnPostPaymentAsync()
        {
            Order.OrderStatus = "Preparing";
            Order.PaymentMethod = "Directly"; 

            await _orderServices.Create(Order);
            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostUpdateStatusOderAsync()
        {
            return null;
        }
    }
}
