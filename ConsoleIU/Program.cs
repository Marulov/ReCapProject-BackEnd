using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleIU
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " : " + brand.BrandName);
            }

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + " " + car.CarName + " ----------  " + colorManager.Get(car.ColorId).ColorName);
            }

            foreach (var carDetail in carManager.GetCarDetails())
            {
                Console.WriteLine($"{carDetail.CarName}----{carDetail.BrandName}----{carDetail.ColorName}----{carDetail.DailyPrice}");
            }
        }
    }
}
