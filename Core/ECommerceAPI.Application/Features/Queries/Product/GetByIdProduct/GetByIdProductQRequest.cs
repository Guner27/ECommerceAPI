using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQRequest : IRequest<GetByIdProductQResponse>
    {
        public string Id { get; set; }
    }
}
