

using Core.DataAccess.EntityFramework;
using Entities;

namespace DataAccess.Concrete
{
    public class EfOrderDal:EfEntityRepositoryBase<Order,NorthwindContext>,IOrderDal
    {
    }
}
