using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
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
            ValidationTool.Validate(new ColorValidator(), color);
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);


        }

        public IResult Delete(Color color)
        {
            if (color.ColorId == 1)
            {
                return new ErrorResult(Messages.ColorValueInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorsListed);
        }

        public IDataResult<List<Color>> GetColorByColorId(int id)
        {
            if((_colorDal.GetAll(c => c.ColorId == id)).Count>0)
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c=>c.ColorId==id), Messages.ColorsListed);

            return new ErrorDataResult<List<Color>>(Messages.ColorsNotListed);
        }

        public IResult Update(Color color)
        {
            if (color.ColorId == 1)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorUpdated);
        }



      

    }
}