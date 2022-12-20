using Core.Entities;
using Entities.Cocnrete;
using System;
using System.Collections.Generic;

namespace Entities.Cocnrete
{
    public class DestinationDetails : IEntity
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


        public virtual Guide Guid { get; set; }
        public  virtual Destination Destinations { get; set; }
        public virtual List<Comment> Comments { get; set; }

    }
}
