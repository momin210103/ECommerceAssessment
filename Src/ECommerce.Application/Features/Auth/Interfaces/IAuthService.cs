using ECommerce.Application.Features.Auth.DTOs;

namespace ECommerce.Application.Features.Auth.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(string fullName, string email, string password);

    Task<AuthResponse> LoginAsync(string email, string password);
}