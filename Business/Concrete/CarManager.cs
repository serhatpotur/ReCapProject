using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.CarName.Length > 2)
            {
                _carDal.Add(car);
            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Günlük fiyat 0'dan büyük olmalıdır");
            }
            else if (car.CarName.Length <= 2)
            {
                Console.WriteLine("Açıklama 2 harften fazla olmalıdır");

            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int Id)
        {
            return _carDal.GetAll(c => c.BrandId == Id);
        }

        public List<Car> GetAllByColorId(int Id)
        {
            return _carDal.GetAll(c => c.ColorId == Id);

        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetProductDetails();
        }

        public List<Car> GetDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0 && car.CarName.Length > 2)
            {
                _carDal.Update(car);
            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Günlük fiyat 0'dan büyük olmalıdır");
            }
            else if (car.CarName.Length <= 2)
            {
                Console.WriteLine("Açıklama 2 harften fazla olmalıdır");

            }
        }
    }
}
