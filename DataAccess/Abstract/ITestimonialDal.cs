using Core.DataAccess;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ITestimonialDal : IGenericRepository<Testimonial>
    {
        public List<Testimonial> GetAllWithInclude();
    }
}
