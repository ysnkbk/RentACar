using Business.Abstract;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entitites.DTOs;
using Core.Utilities;
using DataAccess.Abstract;
using Business.Constants;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            if (car.Id == 1)
            {
                return new ErrorResult(Messages.ProductNameInvalid);

            }
            return new SuccessResult(Messages.ProductDeleted);

        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            if (car.Id == 1)
            {
                return new ErrorResult(Messages.ProductNameInvalid);

            }
            return new SuccessResult(Messages.ProductUpdated);
        }


        public IResult Add(Car car)
        {
            if (car.Id == 1)
            {
                return new ErrorResult(Messages.ProductNameInvalid);

            }
            _carDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.ProductsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<CarDetailsDto>> GetAllDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(), Messages.ProductsListed);
        }
    }
}