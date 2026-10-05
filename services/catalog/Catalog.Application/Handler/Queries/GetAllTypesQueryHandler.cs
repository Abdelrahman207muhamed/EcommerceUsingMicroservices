using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Handler.Queries
{
    public class GetAllTypesQueryHandler : IRequestHandler<GetAllTypesQuery, IList<TypeResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITypeRepository _typeRepository;
        public GetAllTypesQueryHandler(
            IMapper mapper,
            ITypeRepository typeRepository
            )
        {
            _mapper= mapper;
            _typeRepository= typeRepository;
        }
        public  async Task<IList<TypeResponseDto>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var typesList = await _typeRepository.GetAllTypes();
            var typesResponseList = _mapper.Map<IList<ProductType>, IList<TypeResponseDto>>(typesList.ToList());
            return typesResponseList;
        }
    }
}
