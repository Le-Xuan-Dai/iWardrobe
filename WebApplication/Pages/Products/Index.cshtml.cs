using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;

namespace WebApplication.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.IWardrobeContext _context;

        public IndexModel(BusinessObjects.IWardrobeContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.User).ToListAsync();
        }
    }
}
