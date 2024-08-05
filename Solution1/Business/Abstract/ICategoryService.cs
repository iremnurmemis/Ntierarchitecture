

using Core;
using Entities;

namespace Business
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        Category getById(int categoryId);
    }
}
