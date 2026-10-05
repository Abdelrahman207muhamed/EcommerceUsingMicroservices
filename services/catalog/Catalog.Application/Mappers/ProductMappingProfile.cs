using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Spec;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Mappers
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductBrand, BrandResponseDto>().ReverseMap();
            CreateMap<Product, ProductResponsDto>().ReverseMap();
            CreateMap<ProductType, TypeResponseDto>().ReverseMap();
            CreateMap<Pagination<Product>, Pagination<ProductResponsDto>>().ReverseMap();
        }
    }
}
