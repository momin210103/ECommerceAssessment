using ECommerce.Application.Features.Products.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products
            .Include(x => x.Category)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product?> GetByNameAsync(string name)
    {
        return await _context.Products
            .FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<bool> CategoryExistsAsync(Guid categoryId)
    {
        return await _context.Categories
            .AnyAsync(x => x.Id == categoryId);
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public async Task<List<Product>> GetProductsByIdsAsync(List<Guid> productIds)
    {
        return await _context.Products
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync();
    }
}