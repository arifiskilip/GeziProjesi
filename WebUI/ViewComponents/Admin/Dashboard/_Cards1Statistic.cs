using DataAccess.Cocnrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebUI.ViewComponents.Admin.Dashboard
{
    public class _Cards1Statistic : ViewComponent
    {
        TourContext context = new TourContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Destinations.Count();
            ViewBag.v2 = context.Users.Count();
            return View();
        }
    }
}
