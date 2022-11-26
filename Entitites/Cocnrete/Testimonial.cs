using Core.Entities;

namespace Entities.Cocnrete
{
    public class Testimonial : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }


        public AppUser AppUser { get; set; }
    }
}
