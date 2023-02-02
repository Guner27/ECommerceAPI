using ECommerceAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQHandler : IRequestHandler<GetByIdProductQRequest, GetByIdProductQResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetByIdProductQHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetByIdProductQResponse> Handle(GetByIdProductQRequest request, CancellationToken cancellationToken)
        {
            ECommerceAPI.Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.Id, false);
            return new()
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}
