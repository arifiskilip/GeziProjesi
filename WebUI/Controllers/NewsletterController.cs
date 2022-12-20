using Business.Abstract;
using Entities.Cocnrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebUI.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly INewsLetterService _newsletterService;

        public NewsletterController(INewsLetterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        [HttpGet]
        public IActionResult _NewsletterPartial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult _NewsletterPartial(NewsLetter newsLetter)
        {
            var datas = _newsletterService.GetAll().Data;
            bool isNull =false;
            newsLetter.Status = true;
            if (datas.Count>0)
            {
                foreach (var item in datas)
                {
                    if (isNull = item.Email.ToLower() == newsLetter.Email.ToLower())
                    {
                        isNull = false;
                        break;
                    }
                    
                    isNull=true;
                }
                if (!isNull)
                {
                    return RedirectToAction("", "");
                }
                _newsletterService.Add(newsLetter);
                return RedirectToAction("", "");
            }           
            _newsletterService.Add(newsLetter);
            return RedirectToAction("","");
        }
    }
}
