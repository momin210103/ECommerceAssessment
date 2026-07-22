using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Orders.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetAllAsync();

    Task<Order?> GetByIdAsync(Guid id);

    Task<Order?> GetByOrderNumberAsync(string orderNumber);

    Task AddAsync(Order order);

    Task UpdateAsync(Order order);

    Task DeleteAsync(Order order);

    Task SaveChangesAsync();
}