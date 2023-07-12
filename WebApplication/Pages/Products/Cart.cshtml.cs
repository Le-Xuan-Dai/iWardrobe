using BusinessObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Pages.Products
{
    public class CartModel : PageModel
    {
        private readonly CartDetailServices _cartDetailServices;
        private readonly UserServices _userServices;
        private readonly UserManager<User> _userManager ;
        private readonly ProductServices _productServices;

        public CartModel(CartDetailServices cartDetailServices, UserServices userServices, UserManager<User> userManager, ProductServices productServices)
        {
            _cartDetailServices = cartDetailServices;
            _userServices = userServices;
            _userManager = userManager;
            _productServices = productServices;
        }

        [BindProperty]
        public CartDetail cartDetail { get; set; }

        public List<Product> RandomProduct { get; set; }
        public List<Product> listCartProduct { get; set; }
        public List<CartDetail> CartDetail { get; set; }
        [BindProperty]
        public string quantityUpdateAction { get; set; }
        [BindProperty]
        public int cartDetailId { get; set; }
        [BindProperty]
        public CartDetail DetailCart { get; set; }

        public List<Voucher> Voucher { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var userClaim = await _userManager.GetUserAsync(this.User);
            CartDetail = await _cartDetailServices.GetAll().Where(c => c.UserId == userClaim.Id).ToListAsync();
            User user = _userServices.FirstOrDefault(u => u.Id == userClaim.Id);
            listCartProduct = GetListProductInCart(CartDetail);
            RandomProduct = await _productServices.GetAll().ToListAsync();

            if (user.Vouchers == null)
            {
                return Page();
            }
            else
            {
                foreach (var voucher in user.Vouchers)
                {
                    Voucher.Add(voucher);
                }
            }
              
            
            return Page();
        }

        

        public List<Product> GetListProductInCart(List<CartDetail> listCart)
        {
            List<Product> listProduct = new List<Product>();
            foreach (CartDetail cartDetail in listCart)
            {
                listProduct.Add(cartDetail.Product);
            }
            return listProduct;
        }
        
        public async Task<IActionResult> OnPostUpdateQuantityAsync() 
        {
            CartDetail cartDetail = new CartDetail();
            cartDetail = await _cartDetailServices.GetAll().Where(c => c.CartDetailId == cartDetailId).FirstOrDefaultAsync();
            if (quantityUpdateAction.Equals("Increase"))
            {
                cartDetail.Quantity++;
            }
            else
            {
                cartDetail.Quantity--;
                if (cartDetail.Quantity == 0)
                {
                    await _cartDetailServices.Delete(cartDetail);
                }
            }

            await _cartDetailServices.Update(cartDetail);
            return Page();
        }
    }
}
