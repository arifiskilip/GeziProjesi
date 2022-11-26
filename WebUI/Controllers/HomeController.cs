using Entities.Cocnrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    
    [Route("/")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
		private readonly UserManager<AppUser> _userManager;

		public HomeController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
        {
            var IsUserActive = _userManager.FindByNameAsync(User.Identity.Name);
            if (IsUserActive!=null)
            {
                ViewBag.state = "active";
            }
            else
            {
                ViewBag.state = "notActive";
            }
            return View();
        }
    }
}
