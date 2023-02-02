using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProductImageFile.UploadPI
{
    public class UploadPICRequest : IRequest<UploadPICResponse>
    {
        public string Id { get; set; }
        public IFormFileCollection? Files { get; set; }

    }
}
