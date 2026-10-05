using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Spec;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    public class CatalogController : BaseApiController
    {
        private readonly IMediator _mediator;
        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get Product By Id
        [HttpGet]
        [Route("[action]/{id}", Name = "GetProductById")]
        [ProducesResponseType(typeof(ProductResponsDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ProductResponsDto>> GetProductById(string id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //Get Products By Product Name
        [HttpGet]
        [Route("[action]/{ProductName}", Name = "GetProductsByProductName")]
        [ProducesResponseType(typeof(IList<ProductResponsDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponsDto>> GetProductsByProductName(string productName)
        {
            var query = new GetProductsByNameQuery(productName);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //Get All Products
        [HttpGet]
        [Route("GetAllProducts")]
        [ProducesResponseType(typeof(IList<ProductResponsDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponsDto>> GetAllProducts([FromQuery] CatalogSpecParams specs)
        {
            var query = new GetAllProductsQuery(specs);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        //Get All Brands 
        [HttpGet]
        [Route("GetAllBrand")]
        [ProducesResponseType(typeof(IList<BrandResponseDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BrandResponseDto>> GetAllBrand()
        {
            var query = new GetAllBrandsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //Get All Types
        [HttpGet]
        [Route("GetAllTypes")]
        [ProducesResponseType(typeof(IList<TypeResponseDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TypeResponseDto>> GetAllTypes()
        {
            var query = new GetAllTypesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //Create Product
        [HttpPost]
        [Route("CreateProduct")]
        [ProducesResponseType(typeof(ProductResponsDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponsDto>> CreateProduct([FromBody] CreateProductCommand productCommand)
        {
            var result = await _mediator.Send<ProductResponsDto>(productCommand);
            return Ok(result);

        }

        //Update Product
        [HttpPut]
        [Route("UpdateProduct")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponsDto>> UpdateProduct([FromBody] UpdateProductCommand productCommand)
        {
            var result = await _mediator.Send<bool>(productCommand);
            return Ok(result);
        }

        //Delete Product
        [HttpPut]
        [Route("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponsDto>> DeleteProduct(string id)
        {
            var command = new DeleteProductCommand(id);
            var result = await _mediator.Send<bool>(command);
            return Ok(result);
        }

    }
}
