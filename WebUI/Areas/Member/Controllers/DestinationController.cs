using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Member.Controllers
{
	[Area("member")]
	[AllowAnonymous]
	public class DestinationController : Controller
	{
		private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
		{
			var result = _destinationService.GetAll();
			return View(result.Data);
		}
	}
}
