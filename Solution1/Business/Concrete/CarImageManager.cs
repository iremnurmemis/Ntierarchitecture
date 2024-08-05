
using Core;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;

namespace Business
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult? result = BusinessRules.Run(CountByCarId(carImage));
            if(result != null)
            {
                return result;
            }

            string guid = _fileHelper.Add(file);
            carImage.ImagePath = guid;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessDataResult<CarImage>(carImage);

        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            _fileHelper.Delete(carImage.ImagePath!);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var carImages= _carImageDal.GetAll(c=>c.CarId==carId);
            if (carImages.Count == 0)
            {
                carImages.Add(new CarImage() { CarId=carId,ImagePath="default.png"});
                return new SuccessDataResult<List<CarImage>>(carImages);
            }

            return new SuccessDataResult<List<CarImage>>(carImages);
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.Id==Id));
         
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            _fileHelper.Update(file, carImage.ImagePath!);
            carImage.Date= DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessDataResult<CarImage>(carImage );
        }

        private IResult CountByCarId(CarImage carImage)
        {
            if (_carImageDal.GetAll(c => c.CarId == carImage.CarId).Count >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExcended);
            }
            else
            {
                return new SuccessResult();
            }
        }
    }


}
