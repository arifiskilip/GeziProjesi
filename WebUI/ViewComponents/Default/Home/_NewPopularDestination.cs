using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebUI.ViewComponents.Home
{
    public class _NewPopularDestination : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _NewPopularDestination(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {

            List<Entities.Cocnrete.Destination> destinationList = 
                new List<Entities.Cocnrete.Destination>();
            var result = _destinationService.GetAll().Data;
            for (int i = 1; i < 6; i++)
            {
                destinationList.Add(result[i]);
            }


            return View(destinationList);
        }
    }
}
