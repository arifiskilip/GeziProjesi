using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/{controller=Home}/{action=Index}/{id?}")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var result = _commentService.GetCommentDetailWithInclude().Data;
            return View(result);
        }

        public IActionResult Delete(int id)
        {
            var result = _commentService.GetById(id).Data;
            _commentService.Delete(result);
            return RedirectToAction("Index","Comment",new { Area="Admin" });
        }
        public IActionResult AcvtivateDestination(int id)
        {
            var result = _commentService.GetById(id).Data;
            result.Status = true;
            _commentService.Update(result);
            return RedirectToAction("Index", "Comment", new { Area = "Admin" });
        }

        public IActionResult DeactivateDestination(int id)
        {
            var result = _commentService.GetById(id).Data;
            result.Status = false;
            _commentService.Update(result);
            return RedirectToAction("Index", "Comment", new { Area = "Admin" });
        }
    }
}
