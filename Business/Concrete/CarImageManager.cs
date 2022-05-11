using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result.Success)
            {
                carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
                carImage.CarDate = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult("Resim başarıyla yüklendi");
            }
            return result;
        }

        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImage(carImage.CarId));
            if (result.Success)
            {
                _fileHelper.Delete(PathConstants.ImagesPath+carImage.ImagePath);
                _carImageDal.Delete(carImage);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {

            var result = _carImageDal.GetAll();
            if (result!=null)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
            return new ErrorDataResult<List<CarImage>>();
           
        }

        public IDataResult<List<CarImage>> GetByCarImageId(CarImage carImage)
        {

            var result = _carImageDal.GetAll(p=>p.CarId==carImage.CarId);
            if (result != null)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
            return new ErrorDataResult<List<CarImage>>();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImage(carImage.CarId));
            if (result.Success)
            {
                carImage.ImagePath=_fileHelper.Update(file,carImage.ImagePath,PathConstants.ImagesPath);
                _carImageDal.Update(carImage);
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result>=5)
            {
                return new ErrorResult();

            }
            return new SuccessResult() ;
        }
        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
