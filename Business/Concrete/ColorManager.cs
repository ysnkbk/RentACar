using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;


        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            ValidationTool.Validate(new CarValidator(), color);
            _colorDal.Add(color);
            return new SuccessResult(Messages.ProductAdded);


        }

        public IResult Delete(Color color)
        {
            if (color.ColorId == 1)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ProductDeleted);
        }


        public IResult Update(Color color)
        {
            if (color.ColorId == 1)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ProductUpdated);
        }



        IDataResult<List<Color>> IColorService.GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ProductsListed);
        }


        IDataResult<List<Color>> IColorService.GetColorByColorId(int id)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(p => p.ColorId == id), Messages.ProductsListed);
        }


    }
}