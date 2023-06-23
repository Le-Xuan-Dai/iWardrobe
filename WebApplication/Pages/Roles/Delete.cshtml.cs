using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using Services;

namespace WebApplication.Pages.Roles
{
    public class DeleteModel : PageModel
    {
        private readonly RoleServices _roleServices;

        public DeleteModel(RoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        [BindProperty]
        public Role Role { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Role = _roleServices.GetById(id);

            if (Role == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

          await _roleServices.DeleteById(id);

            return RedirectToPage("./Index");
        }
    }
}
