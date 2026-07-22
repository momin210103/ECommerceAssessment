using ECommerce.Application.Features.Auth.DTOs;

namespace ECommerce.Application.Features.Auth.Commands.Register;
using MediatR;
public record RegisterCommand(
    string FullName,
    string Email,
    string Password
) : IRequest<AuthResponse>;