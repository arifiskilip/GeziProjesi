using Business.Abstract;
using Entities.Cocnrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("{admin}/{controller=Home}/{action=Index}/{id?}")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IDestinationService _destinationService;

        public ReservationController(IReservationService reservationService, IDestinationService destinationService)
        {
            _reservationService = reservationService;
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View(_reservationService.GetReservationInclude().Data);
        }
        public IActionResult AcvtivateReservation(int id)
        {
            var result = _reservationService.GetById(id).Data;
            result.Status = true;
            _reservationService.Update(result);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }
        public IActionResult DeactivateReservation(int id)
        {
            var result = _reservationService.GetById(id).Data;
            result.Status = false;
            _reservationService.Update(result);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult EditReservation(int id)
        {
            List<SelectListItem> values = (from x in _destinationService.GetAll().Data.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.Id.ToString(),
                                           }).ToList();
            ViewBag.values = values;
            var result = _reservationService.GetById(id).Data;
            return View(result);
        }
        [HttpPost]
        public IActionResult EditReservation(Reservation reservation)
        {
            var result = _reservationService.Update(reservation);
            if (result.Success)
            {
                return RedirectToAction("Index", "Reservation", new { area = "Admin" });
            }
            return View(result);
        }
        public IActionResult Delete(int id)
        {
            var result = _reservationService.GetById(id).Data;
            _reservationService.Delete(result);
            return RedirectToAction("Index", "Reservation", new { area = "Admin" });
        }
        public IActionResult UserTourHistory(int id)
        {
            var result = _reservationService.GetReservationInclude()
                .Data.Where (x=> x.AppUserId==id && x.Status == true).ToList();
            return View(result);
        }
    }
}
