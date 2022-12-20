using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default.About
{
    public class _AboutMembers : ViewComponent
    {
        private readonly IGuideService _guideService;

        public _AboutMembers(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _guideService.GetAll().Data;
            return View(result);
        }
    }
}
