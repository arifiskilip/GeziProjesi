using Core.DataAccess;
using Entities.Cocnrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICommentDal : IGenericRepository<Comment>
    {
        List<Comment> GetCommentDetailWithInclude();
        List<Comment> GetAllInclude(Expression<Func<Comment, bool>> filter = null);
    }
}
