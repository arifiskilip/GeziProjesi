using Core.Utilities.Results;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAppUserService
    {
        IResult Add(AppUser appUser);
        IResult Delete(AppUser appUser);
        IResult Update(AppUser appUser);
        IDataResult<List<AppUser>> GetAll();
        IDataResult<AppUser> GetById(int id);
    }
}
