using Core.Utilities.Results;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITestimonialService
    {
        IResult Add(Testimonial testimonial);
        IResult Delete(Testimonial testimonial);
        IResult Update(Testimonial testimonial);
        IDataResult<List<Testimonial>> GetAll();
        IDataResult<Testimonial> GetById(int id);
    }
}
