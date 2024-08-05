
using Core;
using DataAccess;
using Entities;

namespace Business
{
    public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category getById(int categoryId)
        {
            return _categoryDal.Get(c=>c.CategoryId == categoryId);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());

        }
    }
}
