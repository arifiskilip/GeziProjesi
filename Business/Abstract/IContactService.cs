using Core.Utilities.Results;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IContactService
    {
        IResult Add(Contact contact);
        IResult Delete(Contact contact);
        IResult Update(Contact contact);
        IDataResult<List<Contact>> GetAll();
        IDataResult<Contact> GetById(int id);
    }
}
