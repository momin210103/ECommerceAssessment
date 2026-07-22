using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Categories.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Guid id);

    Task<Category?> GetByNameAsync(string name);

    Task<List<Category>> GetAllAsync();

    Task AddAsync(Category category);

    Task UpdateAsync(Category category);

    Task DeleteAsync(Category category);

    Task SaveChangesAsync();
}