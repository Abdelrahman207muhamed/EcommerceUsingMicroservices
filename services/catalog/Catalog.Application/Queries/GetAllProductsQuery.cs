using Catalog.Application.Responses;
using Catalog.Core.Spec;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Queries
{
    public class GetAllProductsQuery:IRequest<Pagination<ProductResponsDto>>
    {
        public CatalogSpecParams Spec { get; set; }
        public GetAllProductsQuery(CatalogSpecParams spec)
        {
            Spec = spec;
        }
    }
}
