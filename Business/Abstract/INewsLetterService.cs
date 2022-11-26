using Core.Utilities.Results;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface INewsLetterService
    {
        IResult Add(NewsLetter newsLetter);
        IResult Delete(NewsLetter newsLetter); 
        IResult Update(NewsLetter newsLetter);
        IDataResult<List<NewsLetter>> GetAll();
        IDataResult<NewsLetter> GetById(int id);
    }
}
