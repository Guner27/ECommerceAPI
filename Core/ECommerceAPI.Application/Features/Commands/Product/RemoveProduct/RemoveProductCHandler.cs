using ECommerceAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.Product.RemoveProduct
{
    public class RemoveProductCHandler : IRequestHandler<RemoveProductCRequest, RemoveProductCResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;

        public RemoveProductCHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<RemoveProductCResponse> Handle(RemoveProductCRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.RemoveAsync(request.Id);
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
