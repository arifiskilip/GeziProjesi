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
    public class EfMessageDal : GenericRepositoryBase<Message, TourContext>, IMessageDal
    {
        public List<Message> GetAllInclude(Expression<Func<Message, bool>> filter = null)
        {
            using (TourContext context = new TourContext())
            {
               return filter == null ? context.Message.Include(x => x.AppUser).ToList() :
                    context.Message.Include(x=>x.AppUser).Where(filter).ToList();
            }
        }
    }
}
