using ECommerceAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCHandle : IRequestHandler<CreateProductCRequest, CreateProductCResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;

        public CreateProductCHandle(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<CreateProductCResponse> Handle(CreateProductCRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            });
            await _productWriteRepository.SaveAsync();

            return new();
        }
    }
}
