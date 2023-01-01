using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity 
    {
        private readonly ECommerceAPIDbContext _context;
        public ReadRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();     //DvSet türünden Generic olarak nesnesini döndürür.

        public IQueryable<T> GetAll() => Table;
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            =>Table.Where(method);
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
            =>await Table.FirstOrDefaultAsync(method);
        public async Task<T> GetByIdAsync(string id)
            => await Table.FirstOrDefaultAsync(data => data.Id ==Guid.Parse(id));

        //Generic çalıştığımız için elde bir Id yok. bu yüzden FirstOrDefoult vs. kullanamıyoruz.
        //Bu tarz çalışmalarda yapılması gereken iki yol vardır. ya Reflection'a gireceksin. Ya da aşağıdaki gibi Marker Patern'a (İşaretleyici Patern) uygun bir alt yapıda çalışma sergilemen gerekir. Bu interfacenin alacağı T Tipini teee interfacen bu yana BaseEntity olarak tasarlarsak o zmn firtOrDefaul kullanabiliriz.

    }
}
