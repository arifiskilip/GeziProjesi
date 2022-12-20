using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Migrations;
using Entities.Cocnrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Cocnrete.EntityFramework
{
    public class EfTestimonialDal : GenericRepositoryBase<Testimonial, TourContext>, ITestimonialDal
    {
        public List<Testimonial> GetAllWithInclude()
        {
            using (var context = new TourContext())
            {
                return context.Testimonials.Include(x => x.AppUser)
                    .ToList();
            }
        }
    }
}
