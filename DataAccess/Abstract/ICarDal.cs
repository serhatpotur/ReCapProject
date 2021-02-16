using Core.DataAccess;
using Entities.Concrete;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetProductDetails();
    }
}
