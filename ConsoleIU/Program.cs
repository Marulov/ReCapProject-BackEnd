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
            RentalManager rentalManager = new RentalManager(new EfRentalDal());


            var result = rentalManager.GetByRentalCarId(1);
            if (result.Success)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.CarName + " : " + rental.CustomerName);
                }
            }

            //foreach (var brand in brandManager.GetAll().Data)
            //{
            //    Console.WriteLine(brand.BrandId + " : " + brand.BrandName);
            //}
            //var result = carManager.GetAll();
            //if (result.Success)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine(car.CarId + " " + car.CarName + " ----------  " + colorManager.Get(car.ColorId).Data.ColorName);
            //    }

            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}


            //foreach (var carDetail in carManager.GetCarDetails().Data)
            //{
            //    Console.WriteLine($"{carDetail.CarName}----{carDetail.BrandName}----{carDetail.ColorName}----{carDetail.DailyPrice}");
            //}

            //foreach (var carById in carManager.GetCarsByBrandId(1).Data)
            //{
            //    Console.WriteLine($"{carById.CarId}----{carById.CarName}----{carById.BrandName}----{carById.ColorName}");
            //}
        }
    }
}
