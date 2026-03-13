using AutoMapper;
using KiranaAppV1.Core.DTOs.Responses;
using KiranaAppV1.Core.Interfaces;

namespace KiranaAppV1.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductResponseDTO> GetProductDetailsAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if(product == null) return null;

        return _mapper.Map<ProductResponseDTO>(product);
    }
}