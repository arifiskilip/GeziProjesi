using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("{admin}/{controller=Home}/{action=Index}/{id?}")]
    public class DestinationDetailController : Controller
    {
        private readonly IDestinationDetailService _destinationDetailService;

        public DestinationDetailController(IDestinationDetailService destinationDetailService)
        {
            _destinationDetailService = destinationDetailService;
        }

        public IActionResult WritingsCreatedByGudie(int id)
        {
            var result = _destinationDetailService.GetAll()
                .Data.Where(x=> x.GuideId==id).ToList();
            ViewBag.count=result.Count();
            return View(result);
        }
    }
}
