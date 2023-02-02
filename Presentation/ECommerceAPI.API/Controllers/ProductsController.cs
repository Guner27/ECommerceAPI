using ECommerceAPI.Application.Features.Commands.Product.CreateProduct;
using ECommerceAPI.Application.Features.Commands.Product.RemoveProduct;
using ECommerceAPI.Application.Features.Commands.Product.UpdateProduct;
using ECommerceAPI.Application.Features.Commands.ProductImageFile.RemovePI;
using ECommerceAPI.Application.Features.Commands.ProductImageFile.UploadPI;
using ECommerceAPI.Application.Features.Queries.Product.GetAllProduct;
using ECommerceAPI.Application.Features.Queries.Product.GetByIdProduct;
using ECommerceAPI.Application.Features.Queries.ProductImageFile.GetProductImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQRequest getByIdProductQRequest)
        {
            GetByIdProductQResponse response = await _mediator.Send(getByIdProductQRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCRequest cRequest)
        {
            CreateProductCResponse response = await _mediator.Send(cRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCRequest request)
        {
            UpdateProductCResponse response = await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCRequest request)
        {
            RemoveProductCResponse response = await _mediator.Send(request);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadPICRequest request)
        {
            request.Files = Request.Form.Files;
            UploadPICResponse response = await _mediator.Send(request);


            return Ok();
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImageQRequest request)
        {
            List<GetProductImageQResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] RemovePICRequest request, [FromQuery] string imageId)
        {
            request.ImageId = imageId;
            RemovePICResponse response = await _mediator.Send(request);
            return Ok();
        }

    }
}
