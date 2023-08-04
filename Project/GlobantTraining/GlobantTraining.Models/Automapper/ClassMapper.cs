using AutoMapper;
using GlobantTraining.DAL.Entities;
using GlobantTraining.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobantTraining.Models.Automapper
{
    public class ClassMapper:Profile
    {
        public ClassMapper() 
        {
            CreateMap<TypeProduct, TypeProductDto>();
            CreateMap<TypeProductDto, TypeProduct>();


            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.TypeProductId,
                         opt => opt.MapFrom(src => src.TypeProduct.Title))
                .ForMember(dest => dest.Price,
                            opt => opt.MapFrom(src => Math.Round(src.Price)));

            CreateMap<ProductDto, Product>();


            CreateMap<ProductDetail, ProductDetailDto>()
            .ForMember(dest => dest.ProductDetailId,
                         opt => opt.MapFrom(src => src.ProductId));
            CreateMap<ProductDetailDto, ProductDetail>();
        }
    }
}
    