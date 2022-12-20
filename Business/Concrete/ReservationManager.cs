using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Cocnrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Cocnrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public IDataResult<List<Reservation>> ActiveReservations(int id)
        {
           return new SuccessDataResult<List<Reservation>>(_reservationDal.GetReservationInclude().Where(x => x.Status == true && x.AppUserId == id).ToList());
        }

        public IResult Add(Reservation reservation)
        {
            _reservationDal.Add(reservation);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(Reservation reservation)
        {
            _reservationDal.Delete(reservation);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<Reservation>> GetAll()
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll());
        }

        public IDataResult<Reservation> GetById(int id)
        {
            return new SuccessDataResult<Reservation>(_reservationDal.Get(x => x.Id == id));
        }

        public IDataResult<List<Reservation>> GetReservationInclude()
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetReservationInclude());
        }

        public IDataResult<List<Reservation>> PastDestinations(int id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetReservationInclude().Where(x => x.Status == true 
            && x.Destination.DestinationDate<DateTime.Now && x.AppUserId==id).ToList());
        }

        public IDataResult<List<Reservation>> ReservationPendingConfirmation(int id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetReservationInclude().Where(x => x.Status == false
            && x.AppUserId == id).ToList());
        }

        public IResult Update(Reservation reservation)
        {
            _reservationDal.Update(reservation);
            return new SuccessResult(Messages.SuccessfullyModified);
        }
    }
}
