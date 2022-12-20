using Core.Utilities.Results;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessageService 
    {
        IResult Add(Message message);
        IResult Delete(Message message);
        IResult Update(Message message);
        IDataResult<List<Message>> GetAll();
        IDataResult<Message> GetById(int id);
    }
}
