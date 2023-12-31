using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Pages.Payments
{
    [Authorize]
    public class PaymentModel : PageModel
    {
        public const string DIRECT_PAYMENT = "Pay Directly";
        public const string DEEFAULT_STATUS = "PENDING";


        private readonly ICartDetailServices _cartDetailServices;
        private readonly IOrderServices _orderServices;
        private readonly UserManager<User> _userManager;

        public PaymentModel(ICartDetailServices cartDetailServices, IOrderServices orderServices, UserManager<User> userManager)
        {
            _cartDetailServices = cartDetailServices;
            _orderServices = orderServices;
            _userManager = userManager;
        }

        [BindProperty]
        public Order Order { get; set; }
        public CartDetail paymentCart { get; set; }
        public User userLoggedin { get; set; }
        public List<Voucher> Voucher { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                var paymentCartId = TempData["paymentCartId"] as int?;
                userLoggedin = await _userManager.GetUserAsync(User);
                paymentCart = await _cartDetailServices.GetAll().Include(p => p.Product).FirstOrDefaultAsync(c => c.CartDetailId == paymentCartId);
                TempData["paymentCart"] = paymentCart.CartDetailId;
            }
            catch (Exception e)
            {
                return NotFound();
            }

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
                if (Order != null)
                {
                    order.DeliverMethod = Order.DeliverMethod;
                    order.DeliverDetais = Order.DeliverDetais;
                    order.PaymentDetais = Order.PaymentDetais;
                    order.Note = Order.Note;
                }
                else
                {
                    order.DeliverMethod = "Self-transport";
                    order.DeliverDetais = "Nothing";
                    order.PaymentDetais = "Nothing";
                }
                order.PaymentMethod = DIRECT_PAYMENT;
                order.OrderStatus = DEEFAULT_STATUS;

                await _orderServices.Create(order);
                await _cartDetailServices.Delete(paymentCart);
                return RedirectToPage("./PaymentSuccess");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostUpdateStatusOderAsync()
        {
            return null;
        }
    }
}
