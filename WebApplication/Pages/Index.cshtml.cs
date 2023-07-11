using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using System.Threading.Tasks;
using System;
using BusinessObjects;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserServices _userServices;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public IndexModel(UserServices userServices, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _userServices = userServices;
            _signInManager = signInManager;
            _userManager = userManager;
        }


        public class InputSignInModel
        {
            [Display(Name = "Email/Phone number")]
            public string EmailOrPhoneNumber { get; set; }

            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public class InputSignUpModel
        {
            [Required(ErrorMessage = "Fullname is required.")]
            [DataType("nvarchar")]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Fullname")]
            public string Fullname { get; set; }

            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        [BindProperty]
        public InputSignInModel SignInUser { get; set; }

        [BindProperty]
        public InputSignUpModel SignUpUser { get; set; }

        [BindProperty]
        public string ErrorSignIn { get; set; }

        [BindProperty]
        public string ErrorSignUp { get; set; }

        public bool IsSignUp { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }

        public async Task OnGetAsync(string type, string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorSignIn))
            {
                ModelState.AddModelError(string.Empty, ErrorSignIn);
            }
            IsSignUp = false;

            if (type != null)
            {
                if (type.ToLower().Equals("signup"))
                {
                    IsSignUp = true;
                }
            } 

            returnUrl ??= Url.Content("~/home");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostSignInAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/home");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            var result = await _signInManager.PasswordSignInAsync(SignInUser.EmailOrPhoneNumber, SignInUser.Password, SignInUser.RememberMe, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                var user = _userServices.FirstOrDefault(u => u.PhoneNumber == SignInUser.EmailOrPhoneNumber);
                if (user != null)
                {
                    result = await _signInManager.PasswordSignInAsync(user.UserName, SignInUser.Password, SignInUser.RememberMe, lockoutOnFailure: false);
                }
            }

            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                ErrorSignIn = "Invalid sign in attempt.";
                IsSignUp = false;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/home");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            var user = new User { Fullname = SignUpUser.Fullname, Email = SignUpUser.Email, PhoneNumber = SignUpUser.PhoneNumber, UserName = SignUpUser.Email };
            var result = await _userManager.CreateAsync(user, SignUpUser.Password);
            if (result.Succeeded)
            {
                var resultRole = await _userManager.AddToRolesAsync(user, new string[] { "Customer" });
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }

            ErrorSignUp = "Invalid sign up attempt.";
            IsSignUp = true;
            return Page();
        }
    }
}


