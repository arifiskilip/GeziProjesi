using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/{controller=Home}/{action=Index}/{id?}")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;

        public UserController(IAppUserService appUserService)
        {
            this._appUserService = appUserService;
        }

        public IActionResult Index()
        {
            var result = _appUserService.GetAll().Data;
            return View(result);
        }
        public IActionResult Delete(int id)
        {
            var user = _appUserService.GetById(id).Data;
            _appUserService.Delete(user);
            return RedirectToAction("Index","User",new {Area="Admin"});
        }
    }
}
