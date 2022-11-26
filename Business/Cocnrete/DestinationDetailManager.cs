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

        public IResult Add(DestinationDetail destinationDetail)
        {
            _destinationDetailDal.Add(destinationDetail);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(DestinationDetail destinationDetail)
        {
            _destinationDetailDal.Add(destinationDetail);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<DestinationDetail>> GetAll()
        {
           return new SuccessDataResult<List<DestinationDetail>>(_destinationDetailDal.GetAll());
        }

        public IDataResult<DestinationDetail> GetById(int id)
        {
            return new SuccessDataResult<DestinationDetail>(_destinationDetailDal.Get(x=> x.Id==id));
        }

        public IDataResult<DestinationDetail> GetByIdToRelationship(int id)
        {
            return new SuccessDataResult<DestinationDetail>(_destinationDetailDal.GetByIdToRelationship(id));
        }

        public IResult Update(DestinationDetail destinationDetail)
        {
            _destinationDetailDal.Add(destinationDetail);
            return new SuccessResult(Messages.SuccessfullyModified);
        }
    }
}
