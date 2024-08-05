

using Core.DataAccess.EntityFramework;
using Entities;

namespace DataAccess
{
    public class EfCarImageDal: EfEntityRepositoryBase<CarImage, NorthwindContext>, ICarImageDal
    {
    }
}
