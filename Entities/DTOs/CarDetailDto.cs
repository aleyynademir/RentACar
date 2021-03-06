using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class CarDetailDto:IDto
    {
        public int CarId { get; set; }      
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal UnitPrice { get; set; }
        public string ModelYear { get; set; }
        public string MainImagePath { get; set; }
    }
}
