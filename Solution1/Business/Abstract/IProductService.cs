using Core;
using Entities;
using System.Collections.Generic;

namespace Business
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IResult Add(Product product);
        IResult Update(Product product);
        IDataResult<Product> GetByProductId(int productId);  
    }
}