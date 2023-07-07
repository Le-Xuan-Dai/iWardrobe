using BusinessObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace WebApplication.Areas.Admin.Pages.Users
{
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
