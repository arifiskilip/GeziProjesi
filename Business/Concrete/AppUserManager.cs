using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public IResult Add(AppUser appUser)
        {
            _appUserDal.Add(appUser);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(AppUser appUser)
        {
            _appUserDal.Delete(appUser);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<AppUser>> GetAll()
        {
            return new SuccessDataResult<List<AppUser>>(_appUserDal.GetAll());
        }

        public IDataResult<AppUser> GetById(int id)
        {
            return new SuccessDataResult<AppUser>(_appUserDal.Get(x=> x.Id==id));
        }

        public IResult Update(AppUser appUser)
        {
            _appUserDal.Update(appUser);
            return new SuccessResult(Messages.SuccessfullyModified);
        }
    }
}
