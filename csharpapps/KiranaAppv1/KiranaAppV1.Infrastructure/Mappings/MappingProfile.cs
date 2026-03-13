using AutoMapper;
using KiranaAppV1.Core.DTOs.Responses;
using KiranaAppV1.Core.Entities;

namespace KiranaAppV1.Infrastructure.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Entity -> DTO
        CreateMap<Product, ProductResponseDTO>();

        //DTO -> Entity
        // CreateMap<ProductRequestDTO, Product>();
    }
}