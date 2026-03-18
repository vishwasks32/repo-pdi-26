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

    public async Task<(IEnumerable<Product> Items, int TotalCount)> GetPagedProductsAsync(string? searchTerm, ProductCategory? category, string? sortBy, int pageNumber, int pagSize)
    {
        var query = _context.Products.AsQueryable();

        // Filter
        if(category.HasValue)
        query = query.Where(p=> p.Category == category.Value);

        if(!string.IsNullOrWhiteSpace(searchTerm))
        query = query.Where(p=> p.Name.Contains(searchTerm));

        // Sort
        query = sortBy?.ToLower() switch
        {
            "name_desc" => query.OrderByDescending(p => p.Name),
            "price_asc" => query.OrderBy(p=>p.Price),
            "price_desc" => query.OrderByDescending(p=>p.Price),
            _ => query.OrderBy(p => p.Name)
        };

        // Count and Execute
        var TotalCount = await query.CountAsync();
        var items = await query
        .Skip((pageNumber -1) * pagSize)
        .Take(pagSize)
        .ToListAsync();

        return(items, TotalCount);
    }
}