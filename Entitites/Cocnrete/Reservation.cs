using Core.Entities;

namespace Entities.Cocnrete
{
    public class Reservation : IEntity
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int DestinationId { get; set; }
        public int PersonCount { get; set; }
        public double TotalPrice { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }


        public AppUser AppUser { get; set; }
        public Destination Destination { get; set; }

    }
}
