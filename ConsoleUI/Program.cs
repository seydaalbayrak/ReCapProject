
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
           Car car = new Car() { CarName = "yeni", BrandId = 1, ColorId = 2, DailyPrice = 12365, Description = "yeni", ModelYear = 2022 };
           CarManager carManager =new CarManager(new EfCarDal());
            carManager.Add(car);
        }
    }
}
