using Core.Utilities.Results;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IDestinationDetailService
    {
        IResult Add(DestinationDetail destinationDetail);
        IResult Delete(DestinationDetail destinationDetail);
        IResult Update(DestinationDetail destinationDetail);
        IDataResult<List<DestinationDetail>> GetAll();
        IDataResult<DestinationDetail> GetById(int id);

        IDataResult<DestinationDetail> GetByIdToRelationship(int id);
    }
}
