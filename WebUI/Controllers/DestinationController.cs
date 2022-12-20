using Business.Abstract;
using Entities.Cocnrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
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
            MainModel mainModel = new MainModel();
            var result = _destinationDetailService.GetAll().Data;
            mainModel.DestinationDetails = result;
            return View(mainModel);
        }
        public IActionResult _SearchDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetSearchDestinations(MainModel model)
        {
            var result = _destinationService.GetSearchDestinations(model.GetSearchDestinationsModel.StartingDate
                , model.GetSearchDestinationsModel.EndDate).Data;
            model.GetSearchDestinationsModel.Destinations = result;
            return View(model); 
        }
    }
}
