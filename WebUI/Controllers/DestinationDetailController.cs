using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class DestinationDetailController : Controller
    {
        private readonly IDestinationDetailService _destinationDetailService;

        public DestinationDetailController(IDestinationDetailService destinationDetailService)
        {
            _destinationDetailService = destinationDetailService;
        }

        public IActionResult Index(MainModel model)
        {
            var result = _destinationDetailService.GetAll().Data;
            model.DestinationDetails = result;
            return View(model);
        }
        public IActionResult Detail(int id)
        {
            TempData["id"] = id;
            var destinationDetail = _destinationDetailService.GetByIdToRelationship(id).Data;
            ViewBag.result = destinationDetail;
            return View();
        }
    }
}
