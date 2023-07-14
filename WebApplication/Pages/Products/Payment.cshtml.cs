using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Pages.Cart_Payment
{
    public class PaymentModel : PageModel
    {
        public const String DIRECT_PAYMENT = "Pay Directly";
        public const String DEEFAULT_STATUS = "Preparing";


        private readonly CartDetailServices _cartDetailServices;
        private readonly UserServices _userServices;
        private readonly ProductServices _productServices;
        private readonly OrderServices _orderServices;
        public PaymentModel (CartDetailServices cartDetailServices , UserServices userServices, ProductServices productServices, OrderServices orderServices)
        {
            _cartDetailServices = cartDetailServices;
            _userServices = userServices;
            _productServices = productServices;
            _orderServices = orderServices;
        }
        [BindProperty]
        public Order Order { get; set; }
        public CartDetail paymentCart { get; set; }

        public List<Voucher> Voucher { get; set; }

        public Product productPayment { get; set; }

        public Voucher voucher { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var paymentCartId = TempData["paymentCartId"] as int?;
            paymentCart = await _cartDetailServices.GetAll().Where(c => c.CartDetailId == paymentCartId).FirstOrDefaultAsync();
            var currentUser = await _userServices.GetAll().Where(u => u.Id == paymentCart.UserId).FirstOrDefaultAsync();
            
            TempData["paymentCart"] = paymentCart.CartDetailId;
            

            return Page();
        }

        public async Task<IActionResult> OnPostPurchaseItemAsync()
        {
            var payCart = TempData["paymentCart"] as int?;
            paymentCart = await _cartDetailServices.GetAll().Where(c => c.CartDetailId == payCart).FirstOrDefaultAsync();
            if (paymentCart != null)
            {
                Order order = new Order();
                order.UserId = paymentCart.UserId;
                order.ProductId = paymentCart.ProductId;
                order.DeliverMethod = "Self-transport";
                order.DeliverDetais = "Nothing";
                order.PaymentMethod = DIRECT_PAYMENT;
                order.PaymentDetais = "Nothing";
                order.OrderStatus = DEEFAULT_STATUS;

                await _orderServices.Create(order);

                return RedirectToPage("./Index");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostUpdateStatusOderAsync()
        {
            return null;
        }
    }
}
