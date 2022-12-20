using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Cocnrete;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("{admin}/{controller=Home}/{action=Index}/{id?}")]
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _destinationService.GetById(id).Data;
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Destination destination)
        {
            destination.Status = true;
            var result = _destinationService.Update(destination);
            if (result.Success)
            {
                return RedirectToAction("Index","Destination",new { Area = "Admin" });
            }
            return View(destination);
           
        }
        public IActionResult Delete(int id)
        {
            var result = _destinationService.GetById(id).Data;
            _destinationService.Delete(result);
            return RedirectToAction("Index", "Destination", new { Area = "Admin" });
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(DestinationModel model)
        {
            var images = HttpContext.Request.Form["image"];
            var imageResult = FileHelper.Add(model.Image);
            Destination destination = new Destination
            {
                City = model.City,
                Capacity = model.Capacity,
                Price = model.Price,
                DayNight = model.DayNight,
                Description = model.Description,
                DestinationDate = model.DestinationDate,
                Status = true
            };
            destination.Image = imageResult.Message;
            _destinationService.Add(destination);       
            return RedirectToAction("Index", "Destination", new { Area = "Admin" });
        }
        public IActionResult AcvtivateDestination(int id)
        {
            var result = _destinationService.GetById(id).Data;
            result.Status = true;
            _destinationService.Update(result);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }
        public IActionResult DeactivateDestination(int id)
        {
            var result = _destinationService.GetById(id).Data;
            result.Status = false;
            _destinationService.Update(result);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }
    }
}
