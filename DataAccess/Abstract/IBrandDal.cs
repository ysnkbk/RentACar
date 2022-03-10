using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Entitites.Concrete;
using Entitites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBrandDal:IEntityRepository<Brand>
    {
        

    }
}
