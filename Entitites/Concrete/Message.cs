using Core.Entities;
using System;

namespace Entities.Cocnrete
{
    public class Message : IEntity
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        public AppUser AppUser { get; set; }
    }
}
