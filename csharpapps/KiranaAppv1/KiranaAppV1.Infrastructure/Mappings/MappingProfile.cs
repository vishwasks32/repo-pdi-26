using AutoMapper;
using KiranaAppV1.Core.DTOs.Requests;
using KiranaAppV1.Core.DTOs.Responses;
using KiranaAppV1.Core.Entities;

namespace KiranaAppV1.Infrastructure.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Entity -> DTO
        CreateMap<Product, ProductResponseDTO>()
        .ForMember(dest => dest.Category, opt => opt.MapFrom(src=> src.Category.ToString()));

        //DTO -> Entity
        CreateMap<ProductRequestDTO, Product>()
        .ForMember(dest=>dest.Category, opt=> opt.MapFrom(src=> Enum.Parse<ProductCategory>(src.Category, true)));
    }
}