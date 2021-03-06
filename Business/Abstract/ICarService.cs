using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetByDailyPrice(decimal min,decimal max);
        IDataResult<Car> GetById(int carId);
        IDataResult<CarDetailDto> GetCarDetailsById(int carId);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandIdandColorId(int brandId, int colorId);
        IDataResult<List<CarDetailDto>> GetByBrand(int brandId);
        IDataResult<List<CarDetailDto>> GetByColor(int colorId);
        IDataResult<CarImagesDto> GetImagesDto(int carId);
    }
}
