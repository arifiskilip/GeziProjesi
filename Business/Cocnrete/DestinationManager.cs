using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Cocnrete
{
    public class DestinationManager : IDestinationService
    {
        private readonly IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public IResult Add(Destination destination)
        {
            _destinationDal.Add(destination);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(Destination destination)
        {
            _destinationDal.Delete(destination);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<Destination>> GetAll()
        {
            return new SuccessDataResult<List<Destination>>(_destinationDal.GetAll());
        }

        public IDataResult<Destination> GetById(int id)
        {
            return new SuccessDataResult<Destination>(_destinationDal.Get(x => x.Id == id));
        }

        public IResult Update(Destination destination)
        {
            _destinationDal.Update(destination);
            return new SuccessResult(Messages.SuccessfullyModified);
        }
    }
}
