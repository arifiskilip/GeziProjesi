using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Cocnrete;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("{admin}/{controller=Home}/{action=Index}/{id?}")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var result = _guideService.GetAll().Data;
            return View(result);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _guideService.GetById(id).Data;
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Entities.Cocnrete.Guide guide)
        {
            guide.Status = true;
            var result = _guideService.Update(guide);
            if (result.Success)
            {
                return RedirectToAction("Index", "Guide", new { Area = "Admin" });
            }
            return View(guide);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var guide = _guideService.GetById(id).Data;
            guide.Status = false;
            var result = _guideService.Update(guide);
            if (result.Success)
            {
                return RedirectToAction("Index", "Guide", new { Area = "Admin" });
            }
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(GuideModel guideModel)
        {

            var imageResult = FileHelper.Add(guideModel.ImageUrl);
            Entities.Cocnrete.Guide guide = new Entities.Cocnrete.Guide
            {
                FirstName = guideModel.FirstName,
                LastName = guideModel.LastName,
                Age = guideModel.Age,
                Description = guideModel.Description,
                Email = guideModel.Email,
                InstagramUrl= guideModel.InstagramUrl,
                TwitterUrl= guideModel.TwitterUrl,
                Status=true
            };
            guide.ImageUrl = imageResult.Message;
            var result = _guideService.Add(guide);
            if (result.Success)
            {
                return RedirectToAction("Index", "Guide", new { Area = "Admin" });
            }
            return View(guideModel);
        }
    }
}
