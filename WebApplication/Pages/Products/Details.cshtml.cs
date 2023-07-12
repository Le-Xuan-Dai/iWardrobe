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
using System.Net.NetworkInformation;



namespace WebApplication.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ProductServices _productServices;
        private readonly CartDetailServices _cartDetailServices;
        private readonly UserManager<User> _userManager;

        
        public DetailsModel(ProductServices productServices, CartDetailServices cartDetailServices, UserManager<User> userManager)
        {
            _productServices = productServices;
            _cartDetailServices = cartDetailServices;
            _userManager = userManager;
        }
        public List<CartDetail> listUserCart { get; set; }

        [BindProperty]
        public CartDetail cartDetail { get; set; }
        public Product Product { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var user = _userManager.GetUserAsync(this.User);
            if (id == null)
            {
                return NotFound();
            }

            Product = await _productServices.GetAll().Include(p => p.Category).FirstOrDefaultAsync(m => m.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync()
        {
            var user = await _userManager.GetUserAsync(this.User);
            try
            {
                listUserCart = await _cartDetailServices.GetAll().Where(c => c.UserId == user.Id).ToListAsync();
                if (listUserCart != null)
                {
                    var pro = listUserCart.Where(u => u.ProductId == cartDetail.ProductId).FirstOrDefault();
                    if (pro != null)
                    {
                        pro.Quantity++;
                        await _cartDetailServices.Update(pro);
                        return Page();
                    }
                }
                cartDetail.UserId = user.Id;
                cartDetail.Quantity = 1;
                await _cartDetailServices.Create(cartDetail);
            }
            catch (Exception e)
            {

            }
            return RedirectToPage("./Cart");
        }
    }
}
