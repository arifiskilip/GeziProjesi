using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Cocnrete
{
    public class DestinationDetailManager : IDestinationDetailService
    {
        private readonly IDestinationDetailDal _destinationDetailDal;

        public DestinationDetailManager(IDestinationDetailDal destinationDetailDal)
        {
            _destinationDetailDal = destinationDetailDal;
        }

        public IResult Add(DestinationDetails destinationDetail)
        {
            _destinationDetailDal.Add(destinationDetail);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(DestinationDetails destinationDetail)
        {
            _destinationDetailDal.Add(destinationDetail);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<DestinationDetails>> GetAll()
        {
           return new SuccessDataResult<List<DestinationDetails>>(_destinationDetailDal.GetAllInclude());
        }

        public IDataResult<DestinationDetails> GetById(int id)
        {
            return new SuccessDataResult<DestinationDetails>(_destinationDetailDal.Get(x=> x.Id==id));
        }

        public IDataResult<DestinationDetails> GetByIdToRelationship(int id)
        {
            return new SuccessDataResult<DestinationDetails>(_destinationDetailDal.GetByIdToRelationship(id));
        }

        public IResult Update(DestinationDetails destinationDetail)
        {
            _destinationDetailDal.Add(destinationDetail);
            return new SuccessResult(Messages.SuccessfullyModified);
        }
    }
}
