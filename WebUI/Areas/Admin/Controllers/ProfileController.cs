using Entities.Cocnrete;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/{controller=Home}/{action=Index}/{id?}")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUser appUser)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.FirstName = appUser.FirstName;
            user.LastName = appUser.LastName;
            user.Email = appUser.Email;
            user.PhoneNumber = appUser.PhoneNumber;
            user.Gender = appUser.Gender;
            var result = await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Profile", new { Area = "Admin" });
        }
        public async Task<IActionResult> EditImage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userImageUrl = user.ImageUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditImage(UserEditModel userEdit)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (userEdit.ImageUrl != null)
            {
                var directory = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEdit.ImageUrl.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = directory + "/wwwroot/images/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await userEdit.ImageUrl.CopyToAsync(stream);
                user.ImageUrl = "/images/" + imageName;
                var result = await _userManager.UpdateAsync(user);
            }
            return RedirectToAction("Index", "Profile", new { area = "Admin" });
        }
        public async Task<IActionResult> DeleteImage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.ImageUrl = null;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Profile", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult EditPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditPassword(UserEditModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editModel);
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var hashPassword = await _signInManager.PasswordSignInAsync(user, editModel.LastPassword, false, false);
            if (hashPassword.Succeeded)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, editModel.NewPassword);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

    }
}
