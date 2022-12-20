using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Cocnrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Cocnrete.EntityFramework
{
    public class EfDestinationDetailDal : GenericRepositoryBase<DestinationDetails, TourContext>, IDestinationDetailDal
    {
        public List<DestinationDetails> GetAllInclude(Expression<Func<DestinationDetails, bool>> filter = null)
        {
            using (var context = new TourContext())
            {
                return filter == null ? context.DestinationDetails.Include(x => x.Guid)
                    .Include(x => x.Destinations).ToList() :
                    context.DestinationDetails.Include(x => x.Guid)
                    .Include(x => x.Destinations).Where(filter).ToList();
            }
        }

        public DestinationDetails GetByIdToRelationship(int id)
        {
            using (var context = new TourContext())
            {
                return context.DestinationDetails.Include(x => x.Destinations)
                    .Include(x => x.Guid).SingleOrDefault(x=> x.Id ==id);
            }
        }
    }
}
