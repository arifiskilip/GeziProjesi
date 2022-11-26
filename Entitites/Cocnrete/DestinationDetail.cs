using Core.Entities;
using Entities.Cocnrete;
using System;
using System.Collections.Generic;

namespace Entities.Cocnrete
{
    public class DestinationDetail : IEntity
    {
        public int Id { get; set; }
        public int GuideId { get; set; }
        public int DestinationId { get; set; }
        public string Title1 { get; set; }
        public string Description1 { get; set; }
        public string Title2 { get; set; }
        public string Description2 { get; set; }
        public DateTime PostDate { get; set; }
        public string CoverImage { get; set; }
        public string TitleImage1 { get; set; }
        public string TitleImage2 { get; set; }
        public bool Satus { get; set; }


        public Guide Guid { get; set; }
        public Destination Destination { get; set; }
        List<Destination> Comments { get; set; }

    }
}
