using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Cocnrete
{
    public class Destination : IEntity
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Capacity { get; set; }
        public DateTime DestinationDate { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }


        public virtual List<DestinationDetails> DestinationDetails { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}
