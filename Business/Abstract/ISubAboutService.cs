using Core.Utilities.Results;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISubAboutService
    {
        IResult Add(SubAbout subAbout);
        IResult Delete(SubAbout subAbout);
        IResult Update(SubAbout subAbout);
        IDataResult<List<SubAbout>> GetAll();
        IDataResult<SubAbout> GetById(int id);
    }
}
