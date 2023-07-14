using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using System.Data;

namespace WebApplication.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class UserPageModel: PageModel
    {
        protected const int USER_PER_PAGE = 10;
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly UserManager<User> _userManager;
        protected readonly UserServices _userServices;

        public UserPageModel(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, UserServices userServices)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userServices = userServices;
        }
    }
}
