using Core.Utilities.Results;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IResult Add(Comment comment);
        IResult Delete(Comment comment);
        IResult Update(Comment comment);
        IDataResult<List<Comment>> GetAll();
        IDataResult<List<Comment>> GetCommentDetailWithInclude();
        IDataResult<Comment> GetById(int id);
    }
}
