using Business.Abstract;
using Entities.Cocnrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents.Destination
{
    public class _AddComment : ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDestinationService _destinationService;

        public _AddComment(ICommentService commentService, UserManager<AppUser> userManager, IDestinationService destinationService)
        {
            _commentService = commentService;
            _userManager = userManager;
            _destinationService = destinationService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int destinationId)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var getDestinatin = _destinationService.GetById(destinationId).Data;
            var result = _commentService.GetCommentDetailWithInclude().
                Data.Where(x => x.AppUserId == user.Id).ToList();
            ViewBag.CommentCount = result.Count;
            return View();
        }
    }
}
