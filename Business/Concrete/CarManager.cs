using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
            if (car.DailyPrice > 0 && car.Description.Length > 2)
            {
                _carDal.Add(car);
            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Günlük fiyat 0'dan büyük olmalıdır");
            }
            else if (car.Description.Length <= 2)
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

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

        public List<Car> GetByModelYear(int year)
        {
            return _carDal.GetAll(y => y.ModelYear == year);
        }

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            return _carDal.GetAll(b => b.BrandId == BrandId);
        }

        public List<Car> GetCarsByColorId(int ColorId)
        {
            return _carDal.GetAll(c => c.ColorId == ColorId);
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length > 2)
            {
                _carDal.Add(car);
            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Günlük fiyat 0'dan büyük olmalıdır");
            }
            else if (car.Description.Length <= 2)
            {
                Console.WriteLine("Açıklama 2 harften fazla olmalıdır");

            }
        }
    }
}
