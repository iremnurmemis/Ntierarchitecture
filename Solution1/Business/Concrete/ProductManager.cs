using Core;
using DataAccess;
using Entities;
using FluentValidation;
using System.Collections.Generic;

namespace Business
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService; //microservice
        }

        [ValidationAspect(typeof(ProductValidator))]
        [SecuredOperation("admin")]
        public IResult Add(Product product)
        {
            //aynı isimd eürün eklenemez
            //bir kategoride en fazla 1O ürün olabilir
            //mevcut kategory sayısı 15i geçtiyse sisteme yeni ürün eklenmesin
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfProductNameExists(product.ProductName),CheckIfCategoryLimitExceded());
            if (result == null)
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }
            return result;
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<Product> GetByProductId(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 12)
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);

        }

        //bu method yalnızca bu class içinde kullanılacak bu bir iş kuralı parçacığıdır.
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId) 
        {
            // select counnt * from where categoryId==1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if(result)
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            return new SuccessResult();
        } 
        
        
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if(result.Data.Count >15)
                return new ErrorResult(Messages.CategoryLimitExceded);
            return new SuccessResult();
        }
    }
}