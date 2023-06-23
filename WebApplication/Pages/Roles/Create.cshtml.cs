using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;
using Services;

namespace WebApplication.Pages.Roles
{
    public class CreateModel : PageModel
    {
        private readonly RoleServices _roleServices;

        public CreateModel(RoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Role Role { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           await _roleServices.Create(Role);

            return RedirectToPage("./Index");
        }
    }
}
