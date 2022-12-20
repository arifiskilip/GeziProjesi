using Business.Abstract;
using DataAccess.Cocnrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            MainModel mainModel = new MainModel();
            mainModel.Contact = _contactService.GetById(1).Data;
            return View(mainModel);
        }
    }
}
