using Business.Abstract;
using Entities.Cocnrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Member.Controllers
{
    [Area("member")]
    [Route("member/{controller}/{action}/{id?}")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = _commentService.GetAll()
                .Data.Where(x=> x.AppUserId==user.Id).ToList();
            return View(result);
        }

        public IActionResult Delete(int id)
        {
            var comment = _commentService.GetById(id).Data;
            var result = _commentService.Delete(comment);
            if (result.Success)
            {
                return RedirectToAction("Index", "Comment", new { Area = "member" });
            }
            return View("Error404", "ErrorPage");
        }
    }
}
