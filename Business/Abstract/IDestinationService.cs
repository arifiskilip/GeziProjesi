using Core.Utilities.Results;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IDestinationService
    {
        IResult Add(Destination destination);
        IResult Delete(Destination destination);
        IResult Update(Destination destination);
        IDataResult<List<Destination>> GetAll();
        IDataResult<Destination> GetById(int id);
    }
}
