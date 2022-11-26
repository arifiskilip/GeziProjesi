using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Cocnrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Cocnrete.EntityFramework
{
    public class EfDestinationDetailDal : GenericRepositoryBase<DestinationDetail, TourContext>, IDestinationDetailDal
    {
        public DestinationDetail GetByIdToRelationship(int id)
        {
            using (var context = new TourContext())
            {
                return context.DestinationDetails.Include(x => x.Destination)
                    .Include(x => x.Guid).SingleOrDefault(x=> x.DestinationId ==id);
            }
        }
    }
}
