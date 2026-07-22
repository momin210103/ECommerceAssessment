namespace ECommerce.Application.Features.Auth.Interfaces;

public interface IJwtService
{
    Task<string> GenerateTokenAsync(
        Guid userId,
        string email,
        string fullName,
        IList<string> roles);
}