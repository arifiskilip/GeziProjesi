using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Cocnrete
{
    public class GuideManager : IGuideService
    {
        private readonly IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public IResult Add(Guide guide)
        {
            _guideDal.Add(guide);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(Guide guide)
        {
            _guideDal.Delete(guide);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<Guide>> GetAll()
        {
            return new SuccessDataResult<List<Guide>>(_guideDal.GetAll());
        }

        public IDataResult<Guide> GetById(int id)
        {
            return new SuccessDataResult<Guide>(_guideDal.Get(x => x.Id == id));
        }

        public IResult Update(Guide guide)
        {
            _guideDal.Update(guide);
            return new SuccessResult(Messages.SuccessfullyModified);
        }
    }
}
