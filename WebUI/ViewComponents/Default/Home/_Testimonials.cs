using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class _Testimonials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
