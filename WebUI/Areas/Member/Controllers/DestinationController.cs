using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebUI.Areas.Member.Controllers
{
	[Area("member")]
    [Route("member/{controller}/{action}/{id?}")]
    public class DestinationController : Controller
	{
		private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
		{
			var result = _destinationService.GetAll().Data
				.Where(x=> x.DestinationDate>=DateTime.UtcNow).ToList();
			return View(result);
		}
	}
}
