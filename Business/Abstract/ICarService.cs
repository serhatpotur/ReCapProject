using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        List<Car> GetAllByBrandId(int Id);
        List<Car> GetAllByColorId(int Id);
        List<Car> GetDailyPrice(decimal min, decimal max);
        List<CarDetailDto> GetCarDetails();
    }
}
