using Business.Abstract;
using Entities.Cocnrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                comment.CommentDate = DateTime.Now;
                comment.AppUserId = user.Id;
                comment.Status = true;
                _commentService.Add(comment);
                return RedirectToAction("Index", "Destination");
            }
            return RedirectToAction("Login", "Login");
        }
        [HttpGet]
        public IActionResult AddCommentV2()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddCommentV2(Comment comment)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            comment.CommentDate = DateTime.Now;
            comment.AppUserId = user.Id;
            comment.Status = true;
            _commentService.Add(comment);
            return RedirectToAction("Index", "Destination");
        }
        public IActionResult Delete(int id)
        {
            var comment = _commentService.GetById(id).Data;
            var result = _commentService.Delete(comment);
            if (result.Success)
            {
                return RedirectToAction("Index", "Destination");
            }
            return ViewBag.message = "Silme sırasında bir hata oluştu.";
        }
        [HttpGet]
        public IActionResult Update(int id)
        {

            var comment = _commentService.GetById(id).Data;
            MainModel model = new MainModel
            {
                Comment = comment
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(int id, Comment comment)
        {
            var currentComment = _commentService.GetById(id).Data;
            comment.CommentDate = currentComment.CommentDate;
            comment.AppUserId = currentComment.AppUserId;
            comment.DestinationDetailId = currentComment.DestinationDetailId;
            comment.Id = currentComment.Id;
            comment.Status = currentComment.Status; ;
            var result = _commentService.Update(comment);
            if (result.Success)
            {
                return RedirectToAction("Index", "Destination");
            }
            return View(comment);
        }
    }
}
