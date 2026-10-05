using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Queries
{
    public class GetProductsByBrandQuery:IRequest<IList<ProductResponsDto>>
    {
        public string BrandName { get; set; }
        public GetProductsByBrandQuery(string branName)
        {
            BrandName = branName;
        }
    }
}
