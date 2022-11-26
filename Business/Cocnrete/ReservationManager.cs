using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Cocnrete;
using Entities.DTOs;
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

        public IDataResult<List<ReservationDetailDto>> ActiveReservations()
        {
           return new SuccessDataResult<List<ReservationDetailDto>>(_reservationDal.GetReservationDetails().Where(x => x.Status == true).ToList());
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

        public IDataResult<List<ReservationDetailDto>> PastDestinations()
        {
            return new SuccessDataResult<List<ReservationDetailDto>>(_reservationDal.GetReservationDetails().Where(x => x.Status == true 
            && x.Date<DateTime.Now).ToList());
        }

        public IDataResult<List<ReservationDetailDto>> ReservationPendingConfirmation()
        {
            return new SuccessDataResult<List<ReservationDetailDto>>(_reservationDal.GetReservationDetails().Where(x => x.Status == false).ToList());
        }

        public IResult Update(Reservation reservation)
        {
            _reservationDal.Update(reservation);
            return new SuccessResult(Messages.SuccessfullyModified);
        }
    }
}
