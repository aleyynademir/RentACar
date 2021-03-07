using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
   public  interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //hepsini getiriyor
        T Get(Expression<Func<T, bool>> filter);//hesaplar liste olarak geliyor siz tıklayıp detay alırsınız
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
