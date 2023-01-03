using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
   public interface IReadRepository<T> : IRepository<T> where T:BaseEntity
    {
        IQueryable<T> GetAll(bool tracking =true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);   //Özel tanımlı fonksiyone verilen şart ifadesi doğru olan datalar sorgulanıp getirileceğinin mahiyeti. (Expressions)
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);  //Şarta uygul olan ilkini getir.
        Task<T> GetByIdAsync(string id, bool tracking = true);       //Id ye göre tekil sorgu.
    }
}
