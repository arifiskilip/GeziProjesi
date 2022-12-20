using Business.Abstract;
using Entities.Cocnrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Areas.Member.Controllers
{
    [Area("member")]
    [Route("member/{controller=Home}/{action=Index}/{id?}")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IValidator<Reservation> _validator;

        public ReservationController(IReservationService reservationService, IDestinationService destinationService, UserManager<AppUser> userManager, IValidator<Reservation> validator)
        {
            _reservationService = reservationService;
            _destinationService = destinationService;
            _userManager = userManager;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult AddReservation(int id)
        {

            var result = _destinationService.GetById(id).Data;
            ViewBag.destination = result;
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
        public async Task<IActionResult> AddReservation(int id,Reservation reservation)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(reservation);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            Reservation rsv = new Reservation();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            reservation.Id = rsv.Id;
            reservation.AppUserId = user.Id;
            reservation.DestinationId = id;
            reservation.ReservationDate = DateTime.UtcNow;
            reservation.Status = false;
            _reservationService.Add(reservation);
            return RedirectToAction("Index", "Destination", new { area = "member" });
        }

        public async Task<IActionResult> ActiveReservations(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = _reservationService.ActiveReservations(user.Id).Data;
            return View(result);
        }

        public async Task<IActionResult> ReservationPendingConfirmation(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = _reservationService.ReservationPendingConfirmation(user.Id).Data.OrderByDescending(x=>x.Destination.DestinationDate).ToList();
            return View(result);
        }

        public async Task<IActionResult> PastDestinations(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.id = user.Id;
            var result = _reservationService.PastDestinations(user.Id).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult AddReservation2(int id)
        {
            ReservationModel model = new ReservationModel();
            var result = _destinationService.GetById(id).Data;
            ViewBag.result = result;
            return View();
        }
        [HttpPost]
        public IActionResult AddReservation2(ReservationModel reservation)
        {
            reservation.Reservations.ReservationDate = DateTime.UtcNow;
            reservation.Reservations.Status = true;
            reservation.Reservations.AppUserId = 1;
            _reservationService.Add(reservation.Reservations);
            return RedirectToAction("Index", "Profile", new { area = "member" });
        }
        public IActionResult ReservationCancellation(int id)
        {
            var reservation = _reservationService.GetById(id).Data;
            var result = _reservationService.Delete(reservation);
            if (result.Success)
            {
                return RedirectToAction("Index", "Destination", new { Area = "Member" });
            }
            return View();
        }
    }
}
