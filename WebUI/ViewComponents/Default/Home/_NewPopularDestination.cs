using Business.Abstract;
using Entities.Cocnrete;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var result = _destinationService.GetAll();
            for (int i = 1; i < 6; i++)
            {
                destinationList.Add(result.Data[result.Data.Count - i]);
            }


            return View(destinationList);
        }
    }
}
