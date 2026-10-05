using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Handler.Queries
{
    public class GetAllProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, IList<ProductResponsDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductsByNameQueryHandler(
            IProductRepository productRepository,
            IMapper mapper
            )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IList<ProductResponsDto>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetAllProductsByName(request.Name);
            var productListResponse = _mapper.Map<IList<ProductResponsDto>>(productList);
            return productListResponse;
        }
    }
}
