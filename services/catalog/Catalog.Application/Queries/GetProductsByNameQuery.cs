using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Queries
{
    public class GetProductsByNameQuery:IRequest<IList<ProductResponsDto>>
    {
        public string Name { get; set; }
        public GetProductsByNameQuery(string name)
        {
            Name = name;
        }
    }
}
