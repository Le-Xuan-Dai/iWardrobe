using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Services;

namespace WebApplication.Pages.Categories
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly CategoryServices _categoryServices;

        public IndexModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _categoryServices.GetAll().Include(c => c.User).ToListAsync();
        }
    }
}
