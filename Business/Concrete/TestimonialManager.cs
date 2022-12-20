using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Cocnrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public IResult Add(Testimonial testimonial)
        {
            _testimonialDal.Add(testimonial);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(Testimonial testimonial)
        {
            _testimonialDal.Delete(testimonial);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<Testimonial>> GetAll()
        {
            return new SuccessDataResult<List<Testimonial>>(_testimonialDal.GetAllWithInclude());
        }

        public IDataResult<Testimonial> GetById(int id)
        {
            return new SuccessDataResult<Testimonial>(_testimonialDal.Get(x=> x.Id==id));
        }

        public IResult Update(Testimonial testimonial)
        {
            _testimonialDal.Update(testimonial);
            return new SuccessResult(Messages.SuccessfullyModified);
        }
    }
}
