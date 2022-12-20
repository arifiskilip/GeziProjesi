using Entities.Cocnrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Entities.Models
{
    public class DestinationDetailModel
    {
        public int DestinationId { get; set; }
        public string Title1 { get; set; }
        public string Description1 { get; set; }
        public string Title2 { get; set; }
        public string Description2 { get; set; }
        public DateTime PostDate { get; set; }
        public IFormFile CoverImage { get; set; }
        public IFormFile TitleImage1 { get; set; }
        public IFormFile TitleImage2 { get; set; }

        public List<Destination> Destinations { get; set; }
    }
}
