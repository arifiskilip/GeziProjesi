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
    public class EfCommentDal : GenericRepositoryBase<Comment, TourContext>, ICommentDal
    {
        public List<Comment> GetCommentDetailWithInclude()
        {
            using (TourContext context = new TourContext())
            {
                var result = context.Comments.Include(x => x.DestinationDetail)
                    .Include(x => x.AppUser)
                    .Include(x=> x.DestinationDetail.Destinations).ToList();
                return result;
            }
        }
        public List<Comment> GetAllInclude(Expression<Func<Comment,bool>> filter=null)
        {
            using (TourContext context = new TourContext())
            {
                return filter == null ? context.Set<Comment>().Include(x=> x.DestinationDetail)
                    .Include(x=> x.AppUser).Include(x=> x.DestinationDetail.Destinations).ToList() :
                    context.Set<Comment>().Include(x => x.DestinationDetail)
                    .Include(x => x.AppUser).Include(x => x.DestinationDetail.Destinations).Where(filter).ToList();
            }
        }
    }
}
