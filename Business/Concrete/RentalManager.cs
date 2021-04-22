using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckCarExistsInRentalList(rental));
            if (result != null)
            {
                return result;
            }
 
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAddedSuccess);
        }


        [SecuredOperation("admin")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);

        }

        //[SecuredOperation("user")]
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        //[SecuredOperation("user")]
        public IDataResult<Rental> GetById(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.CarId == carId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail(),Messages.GetAll);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckCarExistsInRentalList(Rental rental)
        {
            if (rental.ReturnDate==null && _rentalDal.GetRentalDetail(c=>c.CarId == rental.CarId).Count>0 )
            {
                return new ErrorResult(Messages.RentalAddedError);
            }

            return new SuccessResult();
        }
    }
}
