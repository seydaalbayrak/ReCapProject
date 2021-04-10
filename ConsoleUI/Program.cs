
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
            //CarTest();
            //BrandTest();
            //ColorTest();

            RentalTest();

        }

        private static void RentalTest()
        {
            Rental rental = new Rental() { CustomerId = 4, CarId = 1, RentDate = DateTime.Now };
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Console.WriteLine(rentalManager.Add(rental).Message);
        }

        private static void ColorTest()
        {
            Color color1 = new Color() { ColorName = "yeni" };
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(color1);
            Color color2 = new Color() { ColorId = 2, ColorName = "yeni" };
            colorManager.Update(color2);
            colorManager.Delete(color1);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine(colorManager.GetById(1).Data.ColorName);
        }

        private static void BrandTest()
        {
            Brand brand1 = new Brand() { BrandName = "yeni" };
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(brand1);
            Brand brand2 = new Brand() { BrandId = 2, BrandName = "yeni" };
            brandManager.Update(brand2);
            brandManager.Delete(brand1);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
            Console.WriteLine(brandManager.GetById(1).Data.BrandName);
        }

        private static void CarTest()
        {
            Car car1 = new Car() { CarName = "3 Nisan", BrandId = 1, ColorId = 2, DailyPrice = 1265, Description = "3 nisan ekleme", ModelYear = 2023 };
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
            Car car2 = new Car() { CarId = 1002, CarName = "4 Nisan", BrandId = 1, ColorId = 2, DailyPrice = 12665, Description = "3 nisan ekleme", ModelYear = 2023 };
            carManager.Update(car2);
            carManager.Delete(car1);
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }

            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(car.CarName);
            }
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(car.CarName);
            }

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            }



        }
    }
}
