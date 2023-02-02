using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFile.GetProductImage
{
    public class GetProductImageQResponse
    {
        public string Path { get; set; }
        public string FileName { get; set; }
        public Guid Id { get; set; }
    }
}
