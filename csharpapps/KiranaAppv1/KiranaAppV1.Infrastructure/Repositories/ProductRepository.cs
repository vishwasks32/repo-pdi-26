using KiranaAppV1.Core.DTOs.Requests;
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

    public async Task<Product> AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return product;
    }
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        var existingProduct = await _context.Products.FindAsync(product.Id);

        _context.Entry(existingProduct).CurrentValues.SetValues(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return;
    }
}