using ECommerceAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFile.GetProductImage
{
    public class GetProductImageQHandler : IRequestHandler<GetProductImageQRequest, List<GetProductImageQResponse>>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetProductImageQHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<List<GetProductImageQResponse>> Handle(GetProductImageQRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
                 .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            if (product != null)
            {
                return product.ProductImageFiles.Select(p => new GetProductImageQResponse
                {
                    Path = p.Path,
                    FileName = p.FileName,
                    Id = p.Id
                }).ToList();
            }
            return new();
        }
    }
}
