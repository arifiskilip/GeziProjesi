using Entities.Cocnrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.ViewComponents.Admin
{
    public class _AdminNavbar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AdminNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userImageUrl = user.ImageUrl;
            ViewBag.userFirstName = user.FirstName;
            ViewBag.userLastName = user.LastName;
            return View();
        }
    }
}
