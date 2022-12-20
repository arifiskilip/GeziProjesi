using Core.DataAccess;
using Entities.Cocnrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IMessageDal : IGenericRepository<Message>
    {
        List<Message> GetAllInclude(Expression<Func<Message,bool>>filter=null);
    }
}
