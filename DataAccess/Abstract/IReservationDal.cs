using Core.DataAccess;
using Entities.Cocnrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IReservationDal : IGenericRepository<Reservation>
    {
        List<ReservationDetailDto> GetReservationDetails();
        List<Reservation> GetReservationInclude();
    }
}
