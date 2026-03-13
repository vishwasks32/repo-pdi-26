using KiranaAppV1.Core.DTOs.Responses;

namespace KiranaAppV1.Core.Interfaces;

public interface IProductService
{
    Task<ProductResponseDTO> GetProductDetailsAsync(int id);
}