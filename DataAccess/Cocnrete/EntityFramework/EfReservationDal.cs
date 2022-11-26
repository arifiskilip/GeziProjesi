using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Cocnrete;
using Entities.DTOs;
using System.Collections.Generic;
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
                                 Id = r.Id,
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
    }
}
