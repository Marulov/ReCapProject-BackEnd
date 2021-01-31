using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            // iş kodları
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            // iş kodları
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            // iş kodları
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            // iş kodları
            return _carDal.GetAllByBrand(brandId);
        }

        public List<Car> GetAllByColor(int colorId)
        {
            // iş kodları
            return _carDal.GetAllByColor(colorId);
        }

        public void Update(Car car)
        {
            // iş kodları
            _carDal.Update(car);
        }
    }
}
