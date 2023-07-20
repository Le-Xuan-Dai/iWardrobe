using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using Microsoft.Extensions.Logging;
using Services;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Services.Interfaces;

namespace WebApplication.Pages.Products
{
    [Authorize(Roles = "Supplier")]
    public class EditModel : PageModel
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IUserServices _userServices;
        private readonly ILogger<IndexModel> _logger;

        public EditModel(IProductServices productServices, ICategoryServices categoryServices, IUserServices userServices, ILogger<IndexModel> logger)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
            _userServices = userServices;
            _logger = logger;
        }

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public string ImageUrlsReview { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product = await _productServices.GetAll().Include(p => p.Category).FirstOrDefaultAsync(m => m.ProductId == id);


            if (Product == null)
            {
                return NotFound();
            }

            ImageUrlsReview = string.Join(',', Product.ImageUrls);
            ViewData["CategoryId"] = new SelectList(await _categoryServices.GetAll().ToListAsync(), "CategoryId", "CategoryName");
            ViewData["UserId"] = new SelectList(await _userServices.GetAll().ToListAsync(), "Id", "Fullname");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Product updateProduct = Product;
                updateProduct.ImageUrls = ImageUrlsReview.Split(',', StringSplitOptions.RemoveEmptyEntries);
                Product = updateProduct;

                await _productServices.Update(updateProduct);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

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

        private bool ProductExists(int id)
        {
            return _productServices.GetById(id) != null;
        }
    }
}
