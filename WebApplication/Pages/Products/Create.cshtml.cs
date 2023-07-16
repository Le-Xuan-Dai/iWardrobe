using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;
using Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace WebApplication.Pages.Products
{
    [Authorize(Roles = "Supplier")]
    public class CreateModel : PageModel
    {
        private readonly ProductServices _productServices;
        private readonly CategoryServices _categoryServices;
        private readonly UserServices _userServices;
        protected readonly UserManager<User> _userManager;

        public CreateModel(ProductServices productServices, CategoryServices categoryServices, UserServices userServices, UserManager<User> userManager)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
            _userServices = userServices;
            _userManager = userManager;
        }

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public string ImageUrlsReview { get; set; }

        public async Task<IActionResult> OnGet()
        {
            string[] initialImages = { "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAMFBMVEXp7vG6vsG3u77s8fTCxsnn7O/f5OfFyczP09bM0dO8wMPk6ezY3eDd4uXR1tnJzdBvAX/cAAACVElEQVR4nO3b23KDIBRA0ShGU0n0//+2KmO94gWZ8Zxmr7fmwWEHJsJUHw8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAwO1MHHdn+L3rIoK6eshsNJ8kTaJI07fERPOO1Nc1vgQm2oiBTWJ+d8+CqV1heplLzMRNonED+4mg7L6p591FC+133/xCRNCtd3nL9BlxWP++MOaXFdEXFjZ7r8D9l45C8y6aG0cWtP/SUGhs2d8dA/ZfGgrzYX+TVqcTNRRO9l+fS5eSYzQs85psUcuzk6igcLoHPz2J8gvzWaH/JLS+95RfOD8o1p5CU5R7l5LkfKEp0mQ1UX7hsVXqDpRrifILD/3S9CfmlUQFhQfuFu0STTyJ8gsP3PH7GVxN1FC4t2sbBy4TNRTu7LyHJbqaqKFw+/Q0ncFloo7CjRPwMnCWqKXQZ75El4nKC9dmcJaou9AXOE5UXbi+RGeJygrz8Uf+GewSn9uXuplnWDZJ7d8f24F/s6iq0LYf9olbS3Q8i5oKrRu4S9ybwaQ/aCkqtP3I28QDgeoK7TBya/aXqL5COx67PTCD2grtdOwH+pQV2r0a7YVBgZoKwwIVFQYG6ikMDVRTGByopjD8ATcKb0UhhRTe77sKs2DV7FKSjId18TUEBYVyLhUThWfILHTDqmI85/2RWWjcE/bhP6OD7maT3h20MHsA47JC3PsW0wcwLhv9t0OOPOIkCn21y2bXXwlyylxiYMPk1SuCSmpfK8bNQvIrpAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADwNX4BCbAju9/X67UAAAAASUVORK5CYII=" };
            string currentUserId =  _userManager.GetUserId(User);
            Product initialProduct = new Product();
            initialProduct.ProductName = "ProductName";
            initialProduct.SellPrice = 0;
            initialProduct.RentPrice = 0;
            initialProduct.ImageUrls = initialImages;
            initialProduct.UserId = currentUserId;

            ImageUrlsReview = string.Join(',', initialImages);
            Product = initialProduct;

            ViewData["CategoryId"] = new SelectList(await _categoryServices.GetAll().ToListAsync(), "CategoryId", "CategoryName");
           /* ViewData["UserId"] = new SelectList(await _userServices.GetAll().ToListAsync(), "Id", "Fullname");*/
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostCreateAsync()
        {
            Product updateProduct = Product;
            updateProduct.ImageUrls = ImageUrlsReview.Split(',', StringSplitOptions.RemoveEmptyEntries);
            Product = updateProduct;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _productServices.Create(Product);

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostPreviewAsync()
        {
            Product updateProduct = Product;
            updateProduct.ImageUrls = ImageUrlsReview.Split(',', StringSplitOptions.RemoveEmptyEntries);
            Product = updateProduct;
            ViewData["CategoryId"] = new SelectList(await _categoryServices.GetAll().ToListAsync(), "CategoryId", "CategoryName");
            ViewData["UserId"] = new SelectList(await _userServices.GetAll().ToListAsync(), "Id", "Fullname");
            return Page();
        }
    }
}
