using Core.Entities;
using Entities.Cocnrete;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Cocnrete
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int DestinationDetailId { get; set; }
        public int AppUserId { get; set; }
        public string CommentDetail { get; set; }
        public DateTime CommentDate { get; set; }
        public bool Status { get; set; }


        public virtual DestinationDetails DestinationDetail { get; set; }
        public virtual AppUser AppUser { get; set; }



    }
}
