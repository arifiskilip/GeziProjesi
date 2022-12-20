using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Admin.Dashboard
{
    public class _DashboardBanner : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
