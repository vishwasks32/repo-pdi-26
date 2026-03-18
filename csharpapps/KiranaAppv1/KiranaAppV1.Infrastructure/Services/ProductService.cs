using AutoMapper;
using KiranaAppV1.Core.DTOs.Requests;
using KiranaAppV1.Core.DTOs.Responses;
using KiranaAppV1.Core.Entities;
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

    public async Task<ProductResponseDTO> CreateProduct(ProductRequestDTO productRequest)
    {
        var product = await _repository.AddAsync(_mapper.Map<Product>(productRequest));

        return _mapper.Map<ProductResponseDTO>(product);
    }

    public async Task<ProductResponseDTO?> GetProductDetailsAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if(product == null)
        {
            throw new KeyNotFoundException("Product does not exist");
        }

        return _mapper.Map<ProductResponseDTO>(product);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
       var product = _repository.GetByIdAsync(id);

       await _repository.DeleteAsync(id);
       return true;
    }

    public async Task<IEnumerable<ProductResponseDTO>> GetAll()
    {
        var products = await _repository.GetProductsAsync();

        var productDTOs = _mapper.Map<IEnumerable<ProductResponseDTO>>(products);

        return productDTOs;
    }

    

    public async Task<ProductResponseDTO> UpdateProduct(int id, ProductRequestDTO productRequest)
    {
        var product = await _repository.GetByIdAsync(id);

        _mapper.Map(productRequest, product);

        await _repository.UpdateAsync(product);

        var productDto = _mapper.Map<ProductResponseDTO>(product);
        return productDto;
    }

    public async Task<PagedResponse<IEnumerable<ProductResponseDTO>>> GetPagedResponseAsync(ProductParameters parameters)
    {
        // Convert String to Enum
        ProductCategory? categoryEnum = null;

        if(!string.IsNullOrEmpty(parameters.Category) && Enum.TryParse<ProductCategory>(parameters.Category, true, out var result))
        {
            categoryEnum = result;
        }

        // use the repo
        var (items, totalCount) = await _repository.GetPagedProductsAsync(
            parameters.SearchTerm,
            categoryEnum,
            parameters.SortBy,
            parameters.PageNumber,
            parameters.PageSize
        );

        // Mapping
        var data = _mapper.Map<IEnumerable<ProductResponseDTO>>(items);

        return new PagedResponse<IEnumerable<ProductResponseDTO>>(
            data,
            totalCount,
            parameters.PageNumber,
            parameters.PageSize
        );
    }
}