using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Products.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(Guid id);

    Task<Product?> GetByNameAsync(string name);

    Task<bool> CategoryExistsAsync(Guid categoryId);
    Task<List<Product>> GetProductsByIdsAsync(List<Guid> productIds);

    Task AddAsync(Product product);

    Task UpdateAsync(Product product);

    Task DeleteAsync(Product product);

    Task SaveChangesAsync();
}