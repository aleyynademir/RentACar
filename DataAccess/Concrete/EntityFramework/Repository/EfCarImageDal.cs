using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCarImageDal:EfEntityRepositoryBase<CarImage,RentACarContext>,ICarImageDal
    {
        
    }
}