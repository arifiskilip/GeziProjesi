using Entities.Cocnrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.ViewComponents.Member
{
    public class _MemberNavBar : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;

        public _MemberNavBar(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await userManager.FindByNameAsync(User.Identity.Name);
            return View(result);
        }
    }
}
