using Core.Entities;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Entities.Cocnrete
{
    public class Guide : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string ImageUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }


        public List<DestinationDetail> DestinationDetails { get; set; }
    }
}
