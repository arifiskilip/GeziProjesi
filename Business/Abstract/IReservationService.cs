using Core.Utilities.Results;
using Entities.Cocnrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IReservationService
    {
        IResult Add(Reservation reservation);
        IResult Delete(Reservation reservation);
        IResult Update(Reservation reservation);
        IDataResult<List<Reservation>> GetAll();
        IDataResult<Reservation> GetById(int id);
        IDataResult<List<ReservationDetailDto>> ActiveReservations();
        IDataResult<List<ReservationDetailDto>> ReservationPendingConfirmation();
        IDataResult<List<ReservationDetailDto>> PastDestinations();
    }
}
