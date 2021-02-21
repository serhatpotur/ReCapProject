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
            // DTO();
            //CreateACar();
            //CarGetAll();
            //CreateRental();
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
            ////UserManager userManager = new UserManager(new EfUserDal());
            ////userManager.Add(new User { Id = 1, FirstName = "Serhat", LastName = "Potur", Email = "sp1@gmail.com", Password = "123" });
            ////CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            ////customerManager.Add(new Customer { Id = 1, UserId = 1, CompanyName = "Potur A.S" });
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental { Id = 1, CarId = 5, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = null });
        }

        private static void CreateACar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Id = 7, BrandName = "FIAT" });
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Id = 7, ColorName = "Bordo" });
            carManager.Add(new Car { Id = 8, BrandId = 7, ColorId = 7, CarName = "Albea", DailyPrice = 30000, ModelYear = 2012 });
        }

        private static void CarGetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} - {1} - {2}", car.Id, car.CarName, car.DailyPrice + " TL");

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
                    Console.WriteLine("{0} - {1} - {2} - {3}", car.BrandName, car.CarName, car.ColorName, car.DailyPrice + " TL");

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

        private static void BrandTest2()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brand = brandManager.GetById(3);
            Console.WriteLine(brand.BrandName);
        }

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
