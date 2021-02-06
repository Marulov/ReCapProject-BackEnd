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

            Console.WriteLine("BrandId si 1 olan araçlar");
            Console.WriteLine("CarId\tBrand\tColor\tModelYear\t DailyPrice\t        Description");
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine($"{car.CarId}\t{brandManager.Get(car.BrandId).BrandName}\t{colorManager.Get(car.ColorId).ColorName}\t{car.ModelYear}\t\t {car.DailyPrice}\t\t{car.Description}");
            }

            Console.WriteLine("\n******************************************************************\n");





        }
    }
}
