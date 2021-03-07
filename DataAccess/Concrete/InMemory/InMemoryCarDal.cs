using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>()
            {
                new Car {CarId=1,BrandId=1,ColorId=5,DailyPrice=150,ModelYear="2020"},
                new Car {CarId=2,BrandId=1,ColorId=4,DailyPrice=180,ModelYear="2019"},
                new Car {CarId=3,BrandId=2,ColorId=5,DailyPrice=110,ModelYear="2021"},
                new Car {CarId=4,BrandId=3,ColorId=1,DailyPrice=90,ModelYear="2015"},
                new Car {CarId=5,BrandId=4,ColorId=1,DailyPrice=125,ModelYear="2020"},
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            var result = _car.SingleOrDefault(c => c.CarId == car.CarId);
            _car.Remove(result);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByCategory(int categoryId)
        {
            return _car.Where(c => c.CarId == categoryId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var result = _car.SingleOrDefault(c => c.CarId == car.CarId);
            result.CarId = car.CarId;
            result.BrandId = car.BrandId;
            result.ColorId = car.ColorId;
            result.DailyPrice = car.DailyPrice;
            

        }
    }
}
