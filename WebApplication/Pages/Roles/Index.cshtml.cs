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
    public class IndexModel : PageModel
    {
        private readonly RoleServices _roleServices;

        public IndexModel(RoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        public IList<Role> Role { get;set; }

        public async Task OnGetAsync()
        {
            Role = await _roleServices.GetAll().ToListAsync();
        }
    }
}

