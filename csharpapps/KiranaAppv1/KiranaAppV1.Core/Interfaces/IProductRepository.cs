using KiranaAppV1.Core.Entities;

namespace KiranaAppV1.Core.Interfaces;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int productId);
}