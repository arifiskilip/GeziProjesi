using Core.DataAccess;
using Entities.Cocnrete;

namespace DataAccess.Abstract
{
    public interface IDestinationDetailDal : IGenericRepository<DestinationDetail>
    {
        DestinationDetail GetByIdToRelationship(int id);
    }
}
