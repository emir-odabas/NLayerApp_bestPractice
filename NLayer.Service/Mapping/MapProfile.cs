﻿using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();    //.ReverseMap() ==>     Product => ProductDto  &&  ProductDto => Product

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();

            CreateMap<ProductUpdateDto, Product>();

            CreateMap<Product, ProductWithCategoryDto>();

            CreateMap<Category, CategoryWithProductsDto>();



        }
    }
}
