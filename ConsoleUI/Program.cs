using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.Entity_Framework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {   
        static void Main(string[] args)
        {
            EfCarDal efCarDal = new EfCarDal();
            efCarDal.Add(new Car
            {
                Id = 1,
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 55000,
                Description = "2020 Model Araç",
                ModelYear = 2020
            });
            ICarService carService = new CarManager(efCarDal);
            foreach (var item in carService.GetAll())
            {
                Console.WriteLine(item.DailyPrice + "-" + item.Description); 
            }
        }
    }
}
