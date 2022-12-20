using Core.DataAccess;
using Entities.Cocnrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IDestinationDetailDal : IGenericRepository<DestinationDetails>
    {
        DestinationDetails GetByIdToRelationship(int id);
        List<DestinationDetails> GetAllInclude(Expression<Func<DestinationDetails,bool>>filter=null);
    }
}
