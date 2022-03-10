using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandId == 1)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.ProductAdded);

        }

        public IResult Delete(Brand brand)
        {
            if (brand.BrandId == 1)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 10)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Brand>> GetBrandsByBrandId(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(p => p.BrandId == id), Messages.ProductsListed);
        }



        public IResult Update(Brand brand)
        {
            if (brand.BrandId == 1)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.ProductAdded);
        }
    }
}