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
        IDataResult<List<Reservation>> ActiveReservations(int id);
        IDataResult<List<Reservation>> ReservationPendingConfirmation(int id);
        IDataResult<List<Reservation>> PastDestinations(int id);
        IDataResult<List<Reservation>> GetReservationInclude(); 
    }
}
