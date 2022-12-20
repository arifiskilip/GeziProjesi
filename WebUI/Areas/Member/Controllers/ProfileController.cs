using Business.Abstract;
using Entities.Cocnrete;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("member/{controller=Home}/{action=Index}/{id?}")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditModel userEdit)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (userEdit.ImageUrl != null)
            {
                var directory = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEdit.ImageUrl.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = directory+"/wwwroot/images/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await userEdit.ImageUrl.CopyToAsync(stream);
                user.ImageUrl = "/images/"+imageName;
                var result = await userManager.UpdateAsync(user);
            }
            return RedirectToAction("Index","Profile", new { area = "member" });
        }
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(AppUser appUser)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            user.FirstName = appUser.FirstName;
            user.LastName = appUser.LastName;
            user.Email = appUser.Email;
            user.Gender = appUser.Gender;
            var result = await userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Profile",new { Area = "Member" });
        }

        [HttpGet]
        public IActionResult EditPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditPassword(UserEditModel editModel)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var hashPassword = await signInManager.PasswordSignInAsync(user, editModel.LastPassword,false,false);
            if (hashPassword.Succeeded)
            {
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, editModel.NewPassword);
                await userManager.UpdateAsync(user);
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

    }
}
