using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class _PopularDestination : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _PopularDestination(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {  
            var result = _destinationService.GetAll();
            return View(result.Data);
        }
    }
}
