using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.Spec;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Handler.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Pagination<ProductResponsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public GetAllProductsQueryHandler(
            IMapper mapper,
            IProductRepository productRepository
            )
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }


        public async Task<Pagination<ProductResponsDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetAllProducts(request.Spec);
            var productResponseList = _mapper.Map<Pagination<ProductResponsDto>>(productList );
            return productResponseList;
        }
    }
}
