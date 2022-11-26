using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Cocnrete
{
    public class SubAboutManager : ISubAboutService
    {
        private readonly ISubAboutDal _subAboutDal;

        public SubAboutManager(ISubAboutDal subAboutDal)
        {
            _subAboutDal = subAboutDal;
        }

        public IResult Add(SubAbout subAbout)
        {
            _subAboutDal.Add(subAbout);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(SubAbout subAbout)
        {
            _subAboutDal.Delete(subAbout);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<SubAbout>> GetAll()
        {
            return new SuccessDataResult<List<SubAbout>>(_subAboutDal.GetAll());
        }

        public IDataResult<SubAbout> GetById(int id)
        {
            return new SuccessDataResult<SubAbout>(_subAboutDal.Get(x => x.Id == id));
        }

        public IResult Update(SubAbout subAbout)
        {
            _subAboutDal.Update(subAbout);
            return new SuccessResult(Messages.SuccessfullyModified);
        }
    }
}
