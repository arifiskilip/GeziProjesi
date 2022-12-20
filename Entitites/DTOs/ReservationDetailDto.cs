using Core.Entities;
using System;

namespace Entities.DTOs
{
    public class ReservationDetailDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DestinationCity { get; set; }
        public int PersonCount { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
