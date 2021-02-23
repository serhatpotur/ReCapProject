using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
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

        public IResult Add(Car car)
        {

            if (car.DailyPrice > 0 && car.Description.Length > 2)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
                //return new SuccessResult("Eklendi"); bu şekilde de olabilir

            }
            return new ErrorResult(Messages.NoCarAdded);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 13)
            {
                return new ErrorDataResult<List<Car>>( Messages.MaintenanceTime);               

            }            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == Id));
        }

        public IDataResult<List<Car>> GetAllByColorId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.ColorId == Id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetProductDetails());
        }

        public IDataResult<List<Car>> GetDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));

        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        //public void Add(Car car)
        //{
        //    if (car.DailyPrice > 0 && car.CarName.Length > 2)
        //    {
        //        _carDal.Add(car);
        //    }
        //    else if (car.DailyPrice <= 0)
        //    {
        //        Console.WriteLine("Günlük fiyat 0'dan büyük olmalıdır");
        //    }
        //    else if (car.CarName.Length <= 2)
        //    {
        //        Console.WriteLine("Açıklama 2 harften fazla olmalıdır");

        //    }
        //}

        //public void Delete(Car car)
        //{
        //    _carDal.Delete(car);
        //}

        //public List<Car> GetAll()
        //{
        //    return _carDal.GetAll();
        //}

        //public List<Car> GetAllByBrandId(int Id)
        //{
        //    return _carDal.GetAll(c => c.BrandId == Id);
        //}

        //public List<Car> GetAllByColorId(int Id)
        //{
        //    return _carDal.GetAll(c => c.ColorId == Id);

        //}

        //public List<CarDetailDto> GetCarDetails()
        //{
        //    return _carDal.GetProductDetails();
        //}

        //public List<Car> GetDailyPrice(decimal min, decimal max)
        //{
        //    return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        //}

        //public void Update(Car car)
        //{
        //    if (car.DailyPrice > 0 && car.CarName.Length > 2)
        //    {
        //        _carDal.Update(car);
        //    }
        //    else if (car.DailyPrice <= 0)
        //    {
        //        Console.WriteLine("Günlük fiyat 0'dan büyük olmalıdır");
        //    }
        //    else if (car.CarName.Length <= 2)
        //    {
        //        Console.WriteLine("Açıklama 2 harften fazla olmalıdır");

        //    }
        //}
    }
}
