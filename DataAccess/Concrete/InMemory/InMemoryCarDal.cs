using DataAccess.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=70000,Description="Dosta Gider",ModelYear=2018},
                new Car{Id=2,BrandId=2,ColorId=2,DailyPrice=50000,Description="Yolda Bırakmaz",ModelYear=2015},
                new Car{Id=3,BrandId=3,ColorId=3,DailyPrice=100000,Description="İhtiyaçtan Satılık",ModelYear=2019},
                new Car{Id=4,BrandId=2,ColorId=1,DailyPrice=150000,Description="Arabadan Anlayana",ModelYear=2020},
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            var RemoveToCar = _car.FirstOrDefault(c => c.Id == car.Id);
            _car.Remove(RemoveToCar);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetByBrandId(int BrandId)
        {
            return _car.Where(c => c.BrandId == BrandId).ToList();
        }


        public List<Car> GetByColorId(int ColorId)
        {
            return _car.Where(c => c.ColorId == ColorId).ToList();
        }

        public void Update(Car car)
        {
            var UpdateToCar = _car.FirstOrDefault(c => c.Id == car.Id);
            UpdateToCar.Id = car.Id;
            UpdateToCar.BrandId = car.BrandId;
            UpdateToCar.ColorId = car.ColorId;
            UpdateToCar.Description = car.Description;
            UpdateToCar.DailyPrice = car.DailyPrice;
            UpdateToCar.ModelYear = car.ModelYear;
        }
    }
}
