using Core.Utilities.Results;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IGuideService
    {
        IResult Add(Guide guide);
        IResult Delete(Guide guide);
        IResult Update(Guide guide);
        IDataResult<List<Guide>> GetAll();
        IDataResult<Guide> GetById(int id);
    }
}
