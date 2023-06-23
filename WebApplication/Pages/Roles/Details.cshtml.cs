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
    public class DetailsModel : PageModel
    {
        private readonly RoleServices _roleServices;

        public DetailsModel(RoleServices roleServices)
        {
            _roleServices = roleServices;
        }

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
    }
}
