using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class _SubAbout : ViewComponent
    {
        private readonly ISubAboutService _subAboutService;

        public _SubAbout(ISubAboutService subAboutService)
        {
            _subAboutService = subAboutService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_subAboutService.GetById(1).Data);
        }
    }
}
