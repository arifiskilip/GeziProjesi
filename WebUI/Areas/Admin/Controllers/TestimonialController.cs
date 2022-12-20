using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/{controller=Home}/{action=Index}/{id?}")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var result = _testimonialService.GetAll().Data;
            return View(result);
        }
        public IActionResult ActivateTestimonial(int id)
        {
            var result = _testimonialService.GetById(id).Data;
            result.Status = true;
            _testimonialService.Update(result);
            return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
        }
        public IActionResult DeactivateTestimonial(int id)
        {
            var result = _testimonialService.GetById(id).Data;
            result.Status = false;
            _testimonialService.Update(result);
            return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
        }
    }
}
