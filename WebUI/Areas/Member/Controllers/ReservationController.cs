using Business.Abstract;
using Entities.Cocnrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Member.Controllers
{
    [Area("member")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(IReservationService reservationService, IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _reservationService = reservationService;
            _destinationService = destinationService;
            _userManager = userManager;
        }

        [HttpGet]
        public async  Task<IActionResult> AddReservation()
        {
            List<SelectListItem> values = (from x in _destinationService.GetAll().Data.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.values = values;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddReservation(Reservation reservation)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            reservation.AppUserId = user.Id;
            reservation.Status = false;
            reservation.TotalPrice = reservation.PersonCount * 10;
            _reservationService.Add(reservation);
            return RedirectToAction("Index", "Profile", new { area = "member" });
        }

        public IActionResult ActiveReservations()
        {
            var result = _reservationService.ActiveReservations().Data;
            return View(result);
        }

        public IActionResult ReservationPendingConfirmation()
        {
            var result = _reservationService.ReservationPendingConfirmation().Data;
            return View(result);
        }

        public IActionResult PastDestinations()
        {
            var result = _reservationService.PastDestinations().Data;
            return View(result);
        }

    }
}
