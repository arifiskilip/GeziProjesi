using Entities.Cocnrete;
using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public class GetSearchDestinationsModel
    {
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Destination> Destinations { get; set; }
    }
}
