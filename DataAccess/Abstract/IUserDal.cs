using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
   public  interface IUserDal:IEntityRepository<User>
   {
       List<OperationClaim> GetClaims(User user);
   }
}
