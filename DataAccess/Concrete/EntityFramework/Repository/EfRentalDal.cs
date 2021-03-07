using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail(Expression<Func<Rental,bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join us in context.Users
                             on r.UserId equals us.UserId
                             
                             select new RentalDetailDto
                             {
                                RentalId = r.RentalId,
                                CarId=c.CarId,
                                CarName=b.BrandName+" "+co.ColorName,
                                UserName = us.FirstName+" "+us.LastName,
                                RentDate=r.RentDate,
                                ReturnDate=r.ReturnDate
                             };
                return result.ToList();
                            
            }
        }
    }
}
