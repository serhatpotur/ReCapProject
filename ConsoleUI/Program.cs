using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {   
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new InMemoryCarDal());
            foreach (var item in carService.GetAll())
            {
                Console.WriteLine(item.ModelYear + "-" + item.Description); 
            }
        }
    }
}
