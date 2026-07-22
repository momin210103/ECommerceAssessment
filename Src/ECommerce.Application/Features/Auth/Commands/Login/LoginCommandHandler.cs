

using ECommerce.Application.Features.Auth.DTOs;
using ECommerce.Application.Features.Auth.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler
    : IRequestHandler<LoginCommand, AuthResponse>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<AuthResponse> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        return await _authService.LoginAsync(
            request.Email,
            request.Password);
    }
}