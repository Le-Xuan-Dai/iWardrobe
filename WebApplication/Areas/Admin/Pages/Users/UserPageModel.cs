using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Services.Interfaces;
using System.Data;

namespace WebApplication.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class UserPageModel: PageModel
    {
        protected const int USER_PER_PAGE = 10;
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly UserManager<User> _userManager;
        protected readonly IUserServices _userServices;

        public UserPageModel(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, IUserServices userServices)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userServices = userServices;
        }
    }
}
