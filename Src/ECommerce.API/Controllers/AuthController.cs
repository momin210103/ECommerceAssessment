using ECommerce.Application.Features.Auth.Commands.Login;
using ECommerce.Application.Features.Auth.Commands.Register;
using ECommerce.Application.Features.Auth.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
//using LoginRequest = ECommerce.Application.Features.Auth.DTOs.LoginRequest;

namespace ECommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(
            request.FullName,
            request.Email,
            request.Password);

        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(LoginRequest request)
    {
        var command = new LoginCommand(
            request.Email,
            request.Password);

        var response = await _mediator.Send(command);

        return Ok(response);
    }
}