using DataAccess.Cocnrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebUI.ViewComponents.Home
{
    public class _Statistics : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var context = new TourContext())
            {
                ViewBag.tourCount = context.Destinations.Count();
                ViewBag.guideCount = context.Guides.Count();
            }
            return View();
        }
    }
}
