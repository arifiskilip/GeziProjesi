using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Guide.Controllers
{
    [Area("guide")]
    [Route("guide/{controller=Home}/{action=Index}/{id?}")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var result = _destinationService.GetAll().Data;
            return View(result);
        }
    }
}
