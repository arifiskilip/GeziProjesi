using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class _SearchDestination : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
