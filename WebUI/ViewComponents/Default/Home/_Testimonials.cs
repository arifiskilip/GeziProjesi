using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebUI.ViewComponents.Home
{
    public class _Testimonials : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _Testimonials(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        public IViewComponentResult Invoke()
        {
           var result = _testimonialService.GetAll()
                .Data.Where(x=> x.Status==true).ToList();
            return View(result);
        }
    }
}
