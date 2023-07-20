using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebApplication.Pages
{
    [Authorize()]
    public class RegisterSellerModel : PageModel
    {
        protected readonly UserManager<User> _userManager;
        protected readonly IUserServices _userServices;
        private readonly SignInManager<User> _signInManager;
        public RegisterSellerModel(UserManager<User> userManager, IUserServices userServices, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _userServices = userServices;
            _signInManager = signInManager;
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Your wardrobe'brand is required!")]
            [Display(Name = "Your wardrobe'brand")]
            [StringLength(255, MinimumLength = 3, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
            public string BrandName { get; set; }

            [Required(ErrorMessage = "Identification code is required!")]
            [Display(Name = "Identification code")]
            [RegularExpression("^[0-9]+$", ErrorMessage = "Only numeric characters are allowed.")]
            [StringLength(12, MinimumLength = 12, ErrorMessage = "The must be at 12 characters long.")]
            public string IdentificationCode { get; set; }

            [Required(ErrorMessage = "Phone number is required!")]
            [Display(Name = "Phone number")]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumner { get; set; }

            [Required(ErrorMessage = "Address is required!")]
            [Display(Name = "Address")]
            public string Address { get; set; }
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
            string _userId = _userManager.GetUserId(User);
            if (_userId != null)
            {
                var user = _userServices.GetById(_userId);
                user.BrandName = Input.BrandName;
                user.Address = Input.Address;
                user.PhoneNumber = Input.PhoneNumner;
                user.IdentificationCode = Input.IdentificationCode;
                try
                {
                    await _userServices.Update(user);
                    var roles = await _userManager.GetRolesAsync(user);
                    if (!roles.Contains("Supplier"))
                    {
                        await _userManager.AddToRoleAsync(user, "Supplier");
                        await _signInManager.SignInAsync(user, isPersistent: false);
                    }
                    return RedirectToPage("./Home");
                }
                catch
                {
                    return Page();

                }
            }
            return Page();
        }
    }
}
