using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Entities.Cocnrete
{
    public class AppUser : IdentityUser<int>,IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }


        public List<Comment> Comments { get; set; }
        public List<Testimonial> Testimonial { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Message> Messages { get; set; }
    }
}
