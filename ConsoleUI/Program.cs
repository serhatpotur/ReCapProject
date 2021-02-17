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
            //BrandTest();
            //BrandTest2();
            //ColorTest();
            //Data Transformation Object

            DTO();


        }

        private static void DTO()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", car.BrandName, car.CarName, car.ColorName, car.DailyPrice + " TL");

            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);

            }
        }

        private static void BrandTest2()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brand = brandManager.GetById(3);
            Console.WriteLine(brand.BrandName);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);

            }
        }
    }
}
