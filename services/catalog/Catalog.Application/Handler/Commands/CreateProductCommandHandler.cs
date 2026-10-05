using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Handler.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponsDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper
            )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponsDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var productEntity = _mapper.Map<Product>(request);
            var newproduct = await _productRepository.CreateProduct(productEntity);
            var productResponse = _mapper.Map<ProductResponsDto>(newproduct);
            return productResponse;
        }
    }
}
