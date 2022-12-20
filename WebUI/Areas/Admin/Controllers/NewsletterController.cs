using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/{controller=Home}/{action=Index}/{id?}")]
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterService _newsLetterService;

        public NewsLetterController(INewsLetterService newsLetterService)
        {
            _newsLetterService = newsLetterService;
        }

        public IActionResult Index()
        {
            var result = _newsLetterService.GetAll().Data;
            return View(result);
        }

        public IActionResult ActivatedNewsletter(int id)
        {
            var result = _newsLetterService.GetById(id).Data;
            result.Status = true;
            _newsLetterService.Update(result);
            return RedirectToAction("Index", "NewsLetter", new { area = "admin" });
        }
        public IActionResult DeactivatedNewsletter(int id)
        {
            var result = _newsLetterService.GetById(id).Data;
            result.Status = false;
            _newsLetterService.Update(result);
            return RedirectToAction("Index", "NewsLetter", new { area = "admin" });
        }
        public IActionResult Delete(int id)
        {
            var result = _newsLetterService.GetById(id).Data;
            _newsLetterService.Delete(result);
            _newsLetterService.Update(result);
            return RedirectToAction("Index", "NewsLetter", new { area = "admin" });
        }
    }
}
