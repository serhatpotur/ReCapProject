using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.Entity_Framework;
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
            // DTO();
            //CreateACar();
            //CarGetAll();
            CreateRental();
            //GetByRental();
        }

        private static void GetByRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("{0} - {1} - {2}", rental.Id, rental.CarId, rental.CustomerId);

                }
            }
            else
            {
                Console.WriteLine(result.Message);

            }
        }

        private static void CreateRental()
        {
            
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental1 = new Rental { CarId = 5, CustomerId = 2, RentDate = DateTime.Now, ReturnDate = null };

            rentalManager.Add(rental1);
            Console.WriteLine(rentalManager.Add(rental1).Message);
        }

        private static void CreateACar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand {BrandName = "FIAT" });
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color {  ColorName = "Bordo" });
            carManager.Add(new Car { BrandId = 7, ColorId = 7, Description = "Albea", DailyPrice = 30000, ModelYear = 2012 });
        }

        private static void CarGetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} - {1} - {2}", car.Id, car.Description, car.DailyPrice + " TL");

                }
            }
            else
            {
                Console.WriteLine(result.Message);

            }
        }

        private static void DTO()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}", car.BrandName, car.Description, car.ColorName, car.DailyPrice + " TL");

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        //private static void ColorTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    foreach (var color in colorManager.GetAll())
        //    {
        //        Console.WriteLine(color.ColorName);

        //    }
        //}

        //private static void BrandTest2()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    var brand = brandManager.GetById(3);
        //    Console.WriteLine(brand.);
        //}

        //private static void BrandTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());

        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.WriteLine(brand.BrandName);

        //    }
        //}
    }
}
