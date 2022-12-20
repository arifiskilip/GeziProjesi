using Business.Abstract;
using Entities.Cocnrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents.Destination
{
    public class _CommentList : ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public _CommentList(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var destinationDetailId = TempData["id"] as object; 
            int id = Convert.ToInt16(destinationDetailId);
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.myComment = user.Id;
            }           
            var result = _commentService.GetCommentDetailWithInclude().
                Data.Where(x=> x.Status==true && x.DestinationDetailId== id).ToList();
            ViewBag.CommentCount = result.Count;
            return View(result);
        }
    }
}
