﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFile.GetProductImage
{
    public class GetProductImageQRequest : IRequest<List<GetProductImageQResponse>>
    {
        public string Id { get; set; }
    }
}
