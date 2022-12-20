using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default.Contact
{
    public class _MemberMessage : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
