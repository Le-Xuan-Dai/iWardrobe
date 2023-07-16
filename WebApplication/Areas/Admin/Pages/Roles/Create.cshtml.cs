using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Areas.Admin.Pages.Roles;

namespace WebApplication.Areas.Admin.Roles
{
    public class CreateModel : RolePageModel
    {
        public CreateModel(RoleManager<IdentityRole> roleManager) : base(roleManager)
        {
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Role name is required")]
            [Display(Name = "Role Name")]
            [StringLength(255, MinimumLength = 3, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
            public string Name { get; set; }

        }
        [BindProperty]
        public InputModel Input { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newRole = new IdentityRole(Input.Name);
            var result =  await _roleManager.CreateAsync(newRole);
            if (result.Succeeded)
            {
                StatusMessage = $"Create {Input.Name} role successfully!";
                return RedirectToPage("./Index");

            } else
            {
                result.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
            }
            return Page();

        }
    }
}
