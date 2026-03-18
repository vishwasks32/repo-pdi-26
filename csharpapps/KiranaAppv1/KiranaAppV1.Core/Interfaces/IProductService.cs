using KiranaAppV1.Core.DTOs.Requests;
using KiranaAppV1.Core.DTOs.Responses;

namespace KiranaAppV1.Core.Interfaces;

public interface IProductService
{
    Task<ProductResponseDTO> GetProductDetailsAsync(int id);
    Task<ProductResponseDTO> CreateProduct(ProductRequestDTO productRequest);

    Task<IEnumerable<ProductResponseDTO>> GetAll();

    Task<ProductResponseDTO> UpdateProduct(int id, ProductRequestDTO productRequest);

    Task<bool> DeleteProductAsync(int id);

    Task<PagedResponse<IEnumerable<ProductResponseDTO>>> GetPagedResponseAsync(ProductParameters parameters);
}