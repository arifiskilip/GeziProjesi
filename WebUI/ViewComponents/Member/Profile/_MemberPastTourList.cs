using Business.Abstract;
using Entities.Cocnrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.ViewComponents.Member.Profile
{
    public class _MemberPastTourList : ViewComponent
    {
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;

        public _MemberPastTourList(IReservationService reservationService, UserManager<AppUser> userManager)
        {
            _reservationService = reservationService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = _reservationService.PastDestinations(user.Id).Data;
            return View(result);
        }
    }
}
