using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    public interface IRepository<T> where T: BaseEntity      //T'nin Kesinlikle Class olması gerek 
    {
        DbSet<T> Table { get; }
    }
}
