using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Services.Interfaces;

namespace WebApplication.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserServices _userServices;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager, IUserServices userServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userServices = userServices;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [StringLength(255)]
            public string Fullname { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Your wardrobe'brand")]
            [StringLength(255, MinimumLength = 3, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
            public string BrandName { get; set; }

            [Display(Name = "Identification code")]
            [RegularExpression("^[0-9]+$", ErrorMessage = "Only numeric characters are allowed.")]
            [StringLength(12, MinimumLength = 12, ErrorMessage = "The must be at 12 characters long.")]
            public string IdentificationCode { get; set; }

            [Display(Name = "Address")]
            public string Address { get; set; }

            public string Avatar { get; set; }
        }

        private void LoadAsync(User user)
        {
            var data = _userServices.FirstOrDefault(u => u.UserName == user.UserName);

            Username = data.UserName;

            Input = new InputModel
            {
                Fullname = data.Fullname,
                PhoneNumber = data.PhoneNumber,
                BrandName = data.BrandName,
                Address = data.Address,
                IdentificationCode = data.IdentificationCode,
                Avatar = data.Avatar,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                LoadAsync(user);
                return Page();
            }

            user.Fullname = Input.Fullname;
            user.PhoneNumber = Input.PhoneNumber;
            user.BrandName = Input.BrandName;
            user.Address = Input.Address;
            user.IdentificationCode = Input.IdentificationCode;

            await _userServices.Update(user);

         /*   var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }*/

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
