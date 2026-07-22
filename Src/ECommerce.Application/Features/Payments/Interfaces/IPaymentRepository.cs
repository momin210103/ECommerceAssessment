using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Payments.Interfaces;

public interface IPaymentRepository
{
    Task<List<Payment>> GetAllAsync();

    Task<Payment?> GetByIdAsync(Guid id);

    Task<Payment?> GetByOrderIdAsync(Guid orderId);

    Task AddAsync(Payment payment);

    Task UpdateAsync(Payment payment);

    Task DeleteAsync(Payment payment);

    Task SaveChangesAsync();
}