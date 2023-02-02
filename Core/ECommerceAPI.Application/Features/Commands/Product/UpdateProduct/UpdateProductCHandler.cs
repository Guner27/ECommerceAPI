using ECommerceAPI.Application.Repositories;
using MediatR;
using P = ECommerceAPI.Domain.Entities.Product;

namespace ECommerceAPI.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCHandler : IRequestHandler<UpdateProductCRequest, UpdateProductCResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;

        public UpdateProductCHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<UpdateProductCResponse> Handle(UpdateProductCRequest request, CancellationToken cancellationToken)
        {
            P product = await _productReadRepository.GetByIdAsync(request.Id);
            product.Stock = request.Stock;
            product.Name = request.Name;
            product.Price = request.Price;
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
