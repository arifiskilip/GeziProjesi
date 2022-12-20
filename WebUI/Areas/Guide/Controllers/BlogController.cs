using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Cocnrete;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Guide.Controllers
{
    [Area("guide")]
    [Route("guide/{controller=Home}/{action=Index}/{id?}")]
    public class BlogController : Controller
    {
        private readonly IDestinationDetailService _destinationDetailService;
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;


        public BlogController(IDestinationDetailService destinationDetailService, IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _destinationDetailService = destinationDetailService;
            this._destinationService = destinationService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var result = _destinationDetailService.GetAll().Data;
            return View(result);
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            var destination = _destinationService.GetById(id).Data;
            ViewBag.id=destination.Id;
            ViewBag.city=destination.City;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(DestinationDetailModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var coverImage = FileHelper.Add(model.CoverImage);
            var titleImage1 = FileHelper.Add(model.TitleImage1);
            var titleImage2 = FileHelper.Add(model.TitleImage2);
            DestinationDetails destinationDetails = new DestinationDetails
            {
                Description1 = model.Description1,
                Description2 = model.Description2,
                DestinationId = model.DestinationId,
                Title1 = model.Title1,
                Title2 = model.Title2,
                PostDate = DateTime.Now,
                Satus = true,
                GuideId = user.Id,
            };
            destinationDetails.CoverImage = coverImage.Message;
            destinationDetails.TitleImage1 = titleImage1.Message;
            destinationDetails.TitleImage2 = titleImage2.Message;
            _destinationDetailService.Add(destinationDetails);
            return RedirectToAction("Index", "Blog", new { Area = "Guide" });
        }
    }
}
