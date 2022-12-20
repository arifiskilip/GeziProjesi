using Core.Utilities.Results;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IDestinationDetailService
    {
        IResult Add(DestinationDetails destinationDetail);
        IResult Delete(DestinationDetails destinationDetail);
        IResult Update(DestinationDetails destinationDetail);
        IDataResult<List<DestinationDetails>> GetAll();
        IDataResult<DestinationDetails> GetById(int id);

        IDataResult<DestinationDetails> GetByIdToRelationship(int id);
    }
}
