using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Cocnrete.EntityFramework;
using Entities.Cocnrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : GenericRepositoryBase<AppUser,TourContext>, IAppUserDal
    {
    }
}
