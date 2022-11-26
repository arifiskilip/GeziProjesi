using Business.Abstract;
using Entities.Cocnrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebUI.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IDestinationDetailService _destinationDetailService;

        public DestinationController(IDestinationService destinationService, IDestinationDetailService destinationDetailService)
        {
            _destinationService = destinationService;
            _destinationDetailService = destinationDetailService;
        }

        public IActionResult Index()
        {
            var result = _destinationService.GetAll().Data;
            return View(result);
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var result = _destinationDetailService.GetByIdToRelationship(id);
            return View(result.Data);
        }
        [HttpPost]
        public IActionResult Detail(Destination destination)
        {
            return View();
        }
    }
}
