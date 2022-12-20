using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("{admin}/{controller=Home}/{action=Index}/{id?}")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            var result = _messageService.GetAll().Data;
            return View(result);
        }
        public IActionResult Delete(int id)
        {
            var result = _messageService.GetById(id).Data;
            _messageService.Delete(result);
            return RedirectToAction("Index","Message",new {Area="Admin"});
        }
    }
}
