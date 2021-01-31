using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleIU
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager( new InMemoryCarDal());

            //Yeni bir Car nesnesi oluşturduk. Ekleme,silme ve güncelleme işlemlerini yapmak için. 
            Car car1 = new Car { Id = 7, BrandId = 2, ColorId = 1, DailyPrice = 500, Description = "Son Model Araba", ModelYear = 2021 };

            //car1 i ekledik ve listeyi ekrana yazdırdık.
            Console.WriteLine("car1 eklendikten sonra. car1.Id=7");
            carManager.Add(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id);
            }

            //car1 i sildik ve listeyi ekrana yazdırdık
            Console.WriteLine("car1 silindikten sonra");
            carManager.Delete(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id);
            }
            Console.WriteLine("color idsi 2 olan araba idlerini ekrana yazdırdık");
            // Brand veya Color ıd lerini ekrana yazdırma işlemini yaptık
            foreach (var car in carManager.GetAllByColor(2))
            {
                Console.WriteLine(car.Id);
            }
        }
    }
}
