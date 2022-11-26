using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Cocnrete
{
    public class NewsLetterManager : INewsLetterService
    {
        private readonly INewsLetterDal _newsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }

        public IResult Add(NewsLetter newsLetter)
        {
            _newsLetterDal.Add(newsLetter);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(NewsLetter newsLetter)
        {
            _newsLetterDal.Delete(newsLetter);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<NewsLetter>> GetAll()
        {
            return new SuccessDataResult<List<NewsLetter>>(_newsLetterDal.GetAll());
        }

        public IDataResult<NewsLetter> GetById(int id)
        {
            return new SuccessDataResult<NewsLetter>(_newsLetterDal.Get(x=> x.Id==id));
        }

        public IResult Update(NewsLetter newsLetter)
        {
            _newsLetterDal.Update(newsLetter);
            return new SuccessResult(Messages.SuccessfullyModified);
        }
    }
}
