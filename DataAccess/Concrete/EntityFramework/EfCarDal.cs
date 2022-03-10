using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entitites.Concrete;
using Entitites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, EntityUSeContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (EntityUSeContext context=new EntityUSeContext())
            {
                var result = from c in context.Cars
                             join co in context.Color
                             on c.ColorId equals co.ColorId
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             select new CarDetailsDto
                             {
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice

                             };
                return result.ToList();
            }
        }
    }
}