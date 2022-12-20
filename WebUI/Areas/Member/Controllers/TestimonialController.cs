using Business.Abstract;
using Entities.Cocnrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.Areas.Member.Controllers
{
    [Area("member")]
    [Route("member/{controller=Home}/{action=Index}/{id?}")]
    public class TestimonialController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(UserManager<AppUser> userManager, ITestimonialService testimonialService)
        {
            _userManager = userManager;
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Testimonial testimonial)
        {
            var user =await  _userManager.FindByNameAsync(User.Identity.Name);
            testimonial.Status = false;
            testimonial.AppUserId = user.Id;
            var result = _testimonialService.Add(testimonial);
            if (result.Success)
            {
                return RedirectToAction("Index", "Profile", new { Area = "member" });
            }

            return View(testimonial);
        }
    }
}
