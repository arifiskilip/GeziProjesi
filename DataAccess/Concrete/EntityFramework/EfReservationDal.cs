using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Cocnrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;

namespace DataAccess.Cocnrete.EntityFramework
{
    public class EfReservationDal : GenericRepositoryBase<Reservation, TourContext>, IReservationDal
    {
        public List<ReservationDetailDto> GetReservationDetails()
        {
            using (TourContext context = new TourContext())
            {
                var result = from r in context.Reservations
                             join d in context.Destinations on
                             r.DestinationId equals d.Id
                             select new ReservationDetailDto
                             {
                                 
                                 DestinationCity = d.City,
                                 PersonCount = r.PersonCount,
                                 TotalPrice = r.TotalPrice,
                                 Date = d.DestinationDate,
                                 ImageUrl = d.Image,
                                 Status = r.Status,
                             };
                return result.ToList();
            }
        }

        public List<Reservation> GetReservationInclude()
        {
            using (var context = new TourContext())
            {
               return context.Reservations.Include(u => u.AppUser)
                    .Include(d => d.Destination)
                    .OrderBy(x=> x.ReservationDate).ToList();
            }
        }
    }
}
