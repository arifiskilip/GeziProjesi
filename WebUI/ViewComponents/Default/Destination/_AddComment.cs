using Business.Abstract;
using Entities.Cocnrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Destination
{
    public class _AddComment : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _AddComment(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

        //[HttpPost]
        //public IViewComponentResult Invoke(Comment comment)
        //{
        //    return View();
        //}
    }
}
