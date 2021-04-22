using System;
using System.Collections.Generic;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CarImagesDto:IDto
    {
        public CarDetailDto Car { get; set; }
        public List<CarImage> CarImages { get; set; }

       
    }
}