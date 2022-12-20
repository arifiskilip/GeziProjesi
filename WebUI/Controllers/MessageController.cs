using Business.Abstract;
using Entities.Cocnrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult AddMessagePartial()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddMessagePartial(Message message)
        {
            
            if (User.Identity.Name==null)
            {
                return RedirectToAction("Login", "Login");
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            message.AppUserId = user.Id;
            message.Status = true;
            message.Date = DateTime.Now;
            var result = _messageService.Add(message);
            if (result.Success)
            {
                return RedirectToAction("Index", "Contact");
            }
            return View(message);
        }
    }
}
