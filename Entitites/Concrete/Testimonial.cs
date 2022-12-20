using Core.Entities;

namespace Entities.Cocnrete
{
    public class Testimonial : IEntity
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }


        public virtual AppUser AppUser { get; set; }
    }
}
