using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join r in context.Colors
                             on c.ColorId equals r.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 UnitPrice = c.DailyPrice,
                                 ColorName = r.ColorName,
                                 ModelYear = c.ModelYear,
                                 MainImagePath = (context.CarImages.Where(p => p.CarId == c.CarId).Select(p => p.ImagePath).FirstOrDefault() != null) ? context.CarImages.Where(p => p.CarId == c.CarId).Select(p => p.ImagePath).FirstOrDefault() : @"Images\resim-yok.png"


                             };
                return result.ToList();
            }
        }



        public CarDetailDto GetCarsDetails(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars.Where(c => c.CarId == carId)
                             join co in context.Colors
                                 on c.ColorId equals co.ColorId
                             join b in context.Brands
                                 on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 UnitPrice = c.DailyPrice,
                                 CarId = c.CarId,
                                 MainImagePath = (context.CarImages.Where(p => p.CarId == c.CarId).Select(p => p.ImagePath).FirstOrDefault() != null) ? context.CarImages.Where(p => p.CarId == c.CarId).Select(p => p.ImagePath).FirstOrDefault() : @"Images\resim-yok.png",
                                 

                             };
                return result.SingleOrDefault();
            }
        }


    }



}
