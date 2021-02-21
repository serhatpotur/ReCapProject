using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    // IDataResult dememizin sebebi generic olması , success ve message kontrollerini yapabilmemiz
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int Id);
        IDataResult<List<Car>> GetAllByColorId(int Id);
        IDataResult<List<Car>> GetDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
