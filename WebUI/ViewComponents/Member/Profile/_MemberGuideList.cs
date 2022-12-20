using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Member.Profile
{
    public class _MemberGuideList : ViewComponent
    {
        private readonly IGuideService _guideService;

        public _MemberGuideList(IGuideService guideService)
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
