using Core.Entities;
using Entities.Cocnrete;
using System;

namespace Entities.Cocnrete
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int DestinationDetailId { get; set; }
        public int UserId { get; set; }
        public string CommentDetail { get; set; }
        public DateTime CommentDate { get; set; }
        public bool Status { get; set; }


        public DestinationDetail DestinationDetail { get; set; }
        public AppUser AppUser { get; set; }



    }
}
