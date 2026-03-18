using KiranaAppV1.Core.Entities;

namespace KiranaAppV1.Core.Interfaces;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int productId);
    Task<Product> AddAsync(Product product);
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> UpdateAsync(Product product);
    Task DeleteAsync(int id);

    Task<(IEnumerable<Product> Items, int TotalCount)> GetPagedProductsAsync(
        string? searchTerm,
        ProductCategory? category,
        string? sortBy,
        int pageNumber,
        int pagSize
    );
}