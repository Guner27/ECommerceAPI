using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProductImageFile.RemovePI
{
    public class RemovePICRequest : IRequest<RemovePICResponse>
    {
        public string Id { get; set; }
        public string? ImageId { get; set; }
    }
}
