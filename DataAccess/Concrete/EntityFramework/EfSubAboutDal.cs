using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Cocnrete;

namespace DataAccess.Cocnrete.EntityFramework
{
    public class EfSubAboutDal : GenericRepositoryBase<SubAbout, TourContext>, ISubAboutDal
    {
    }
}
