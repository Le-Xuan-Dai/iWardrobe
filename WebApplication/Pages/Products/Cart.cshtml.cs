using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class CartModel : PageModel
    {
        private readonly CartDetailServices _cartDetailServices;
        private readonly UserServices _userServices;
        private readonly UserManager<User> _userManager ;
        private readonly ProductServices _productServices;
        private readonly OrderServices _orderServices;
        public CartModel(CartDetailServices cartDetailServices, UserServices userServices, UserManager<User> userManager, ProductServices productServices, OrderServices orderServices)
        {
            _cartDetailServices = cartDetailServices;
            _userServices = userServices;
            _userManager = userManager;
            _productServices = productServices;
            _orderServices = orderServices;
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

        [BindProperty]
        public int paymentCart { get; set; }

        public string ErrorMessage { get; private set; }

        public async Task<IActionResult> OnGet()
        {
            // String currentUserId = _userManager.GetUserId(User);
            var userClaim = await _userManager.GetUserAsync(this.User);
            CartDetail = await _cartDetailServices.GetAll().Include(c => c.Product).Where(c => c.UserId == userClaim.Id).ToListAsync();
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
            var action = Request.Form["action"];
            var cartId = Int64.Parse(Request.Form["cartId"]);
            var userClaim = await _userManager.GetUserAsync(this.User);
            User user = _userServices.FirstOrDefault(u => u.Id == userClaim.Id);
            var cartDetail = await _cartDetailServices.GetAll().Where(c => c.CartDetailId == cartId).FirstOrDefaultAsync();
            

            if (action.Equals("increase"))
            {
                    cartDetail.Quantity++;
            }
            else
            {
                if(cartDetail == null || cartDetail.Quantity == 0)
                {
                    await _cartDetailServices.Delete(cartDetail);
                    CartDetail = await _cartDetailServices.GetAll().Include(c => c.Product).Where(c => c.UserId == userClaim.Id).ToListAsync();
                    listCartProduct = GetListProductInCart(CartDetail);
                    RandomProduct = await _productServices.GetAll().ToListAsync();
                    return Page();
                }
                cartDetail.Quantity--;
            }

            await _cartDetailServices.Update(cartDetail);
            int quantity = cartDetail.Quantity;
            return new JsonResult(new { quantity });
        }

        public async Task<IActionResult> OnPostPaymentAsync()
        {
            /* var cartData = await _cartDetailServices.GetAll().Where(c => c.CartDetailId == paymentCart).FirstOrDefaultAsync();
             if(paymentCart != null)
             {
                 Order order = new Order();
                 order.UserId = cartData.UserId;
                 order.ProductId = cartData.ProductId;
                 order.DeliverMethod = "Self-transport";
                 order.DeliverDetais = "Nothing";
                 order.PaymentMethod = "Pay directly";
                 order.PaymentDetais = "Nothing";
                 order.OrderStatus = "Preparing";

                 await _orderServices.Create(order);

                 return RedirectToPage("./Index");
             }*/
            TempData["paymentCartId"] = paymentCart;
            return RedirectToPage("/Payments/Payment");
        }

        public async void loadDataToPage()
        {
            var userClaim = await _userManager.GetUserAsync(this.User);
            CartDetail = await _cartDetailServices.GetAll().Where(c => c.UserId == userClaim.Id).ToListAsync();
            User user = _userServices.FirstOrDefault(u => u.Id == userClaim.Id);
            listCartProduct = GetListProductInCart(CartDetail);
            RandomProduct = await _productServices.GetAll().ToListAsync();
        }
    }
}
