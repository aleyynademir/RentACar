﻿using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage, IFormFile file);
        IResult  Delete(CarImage carImage);
        IResult Update(CarImage carImage, IFormFile file);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int carId);
        IDataResult<List<CarImage>> GetByIdList(int carId);

    }
}