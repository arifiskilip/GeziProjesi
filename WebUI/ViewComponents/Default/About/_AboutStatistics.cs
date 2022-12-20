using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebUI.ViewComponents.Default.About
{
    public class _AboutStatistics : ViewComponent
    {
        private readonly IReservationService _reservationService;
        private readonly IGuideService _guideService;
        private readonly IDestinationService _destinationService;

        public _AboutStatistics(IReservationService reservationService, IGuideService guideService, IDestinationService destinationService)
        {
            _reservationService = reservationService;
            _guideService = guideService;
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.CustomerCount = _reservationService.GetAll().Data.Where
                (x => x.Status == true).Sum(x => x.PersonCount);
            ViewBag.GuideCount = _guideService.GetAll().Data
                .Where(x => x.Status == true).Count();
            ViewBag.DestinationCount = _destinationService.GetAll().Data
                .Where(x => x.Status == true).Count();
            return View();
        }
    }
}
