using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Pages
{
    public class PaymentCartModel : PageModel
    {
        private readonly ICartDetailServices _cartDetailServices;
        private readonly IUserServices _userServices;

        public PaymentCartModel(ICartDetailServices cartDetailServices, IUserServices userServices)
        {
            _cartDetailServices = cartDetailServices;
            _userServices = userServices;
        }

        public Product Product { get; set; }
        public List<CartDetail> CartDetail { get; set; }

        public List<Voucher> Voucher { get; set; }
        public async Task<IActionResult> OnGet(string? id,string? username)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                CartDetail = await _cartDetailServices.GetAll().Where(c => c.UserId == id).ToListAsync();
                User user = _userServices.FirstOrDefault(u => u.UserName == username);

                foreach (var voucher in user.Vouchers)
                {
                    Voucher.Add(voucher);
                }
            }
            return Page();
        }
        public async Task<IActionResult> OnPostRemoveItemFromCart(int? id)
        {
            var productRemove = CartDetail.FirstOrDefault(c => c.ProductId == id);
            if(productRemove != null)
            {
                CartDetail.Remove(productRemove);
            }

            return Page(); 
        }
        
    }
}
