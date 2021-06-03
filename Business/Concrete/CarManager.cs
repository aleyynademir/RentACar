using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        private ICarImageService _carImageService;

        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

       // [SecuredOperation("user")]
        //[CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.GetAll);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var carDetail = _carDal.GetCarDetails();
            
            return new SuccessDataResult<List<CarDetailDto>>(carDetail, Messages.GetAll);
        }

        //[CacheRemoveAspect("ICarService.Get")]
       // [SecuredOperation("admin")]
        //[ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        //[CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
           
           
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        //[CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        //[SecuredOperation("user")]
        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new  SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        
        public IDataResult<List<Car>> GetByDailyPrice(decimal min,decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> GetByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
        }

        public IDataResult<CarDetailDto> GetCarDetailsById(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetByIdDetail(carId));
        }

        public IDataResult<CarImagesDto> GetImagesDto(int carId)
        {
            var result = _carDal.GetByIdDetail(carId);
            var imageResult = _carImageService.GetByIdList(carId);
            if (result == null || imageResult.Success == false)
            {
                return new ErrorDataResult<CarImagesDto>();
            }

            var carImagesDto = new CarImagesDto
            {
                Car = result,
                CarImages = imageResult.Data
            };

            return new SuccessDataResult<CarImagesDto>(carImagesDto);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandIdandColorId(int brandId, int colorId)
        {
            var result = _carDal.GetCarDetails(p => p.BrandId == brandId && p.ColorId == colorId);
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }
    }
}
