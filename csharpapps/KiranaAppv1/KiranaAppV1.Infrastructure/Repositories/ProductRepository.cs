using KiranaAppV1.Core.Entities;
using KiranaAppV1.Core.Interfaces;
using KiranaAppV1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KiranaAppV1.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly KiranaAppDbContext _context;

    public ProductRepository(KiranaAppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> GetByIdAsync(int productId)
    {
        return await _context.Products.FindAsync(productId);
    }
}