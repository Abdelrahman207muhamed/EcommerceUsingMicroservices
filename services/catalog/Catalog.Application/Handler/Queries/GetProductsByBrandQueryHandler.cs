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
    public class GetProductsByBrandQueryHandler : IRequestHandler<GetProductsByBrandQuery, IList<ProductResponsDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductsByBrandQueryHandler(
            IProductRepository productRepository,
            IMapper mapper
            )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IList<ProductResponsDto>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
        {
            var products =await _productRepository.GetAllProductsByBrand(request.BrandName);
            var productsResponseList = _mapper.Map<IList<ProductResponsDto>>(products);
            return productsResponseList;
        }
    }
}
