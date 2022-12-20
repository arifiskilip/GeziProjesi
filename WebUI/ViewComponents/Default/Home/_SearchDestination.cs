using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
