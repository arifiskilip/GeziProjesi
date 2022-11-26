using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Cocnrete;

namespace DataAccess.Cocnrete.EntityFramework
{
    public class EfGuideDal : GenericRepositoryBase<Guide, TourContext>,IGuideDal
    {
    }
}
