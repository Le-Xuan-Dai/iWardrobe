using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Services;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace WebApplication.Pages.Categories
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IUserServices _userServices;

        public CreateModel(ICategoryServices categoryServices, IUserServices userServices)
        {
            _categoryServices = categoryServices;
            _userServices = userServices;
        }

        public async Task<IActionResult> OnGetAsync()
        {
        ViewData["UserId"] = new SelectList(await _userServices.GetAll().ToListAsync(), "Id", "Fullname");
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _categoryServices.Create(Category);

            return RedirectToPage("./Index");
        }
    }
}
