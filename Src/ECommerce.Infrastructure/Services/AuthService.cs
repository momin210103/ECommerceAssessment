using ECommerce.Application.Features.Auth.DTOs;
using ECommerce.Application.Features.Auth.Interfaces;
using ECommerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtService _jwtService;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IJwtService jwtService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtService = jwtService;
    }

    // Methods will be added next
    public async Task<AuthResponse> RegisterAsync(string fullName, string email, string password)
    {
        var existingUser = await _userManager.FindByEmailAsync(email);

        if (existingUser != null)
            throw new Exception("Email already exists.");
        var user = new ApplicationUser
        {
            FullName = fullName,
            Email = email,
            UserName = email
        };
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
            throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
        await _userManager.AddToRoleAsync(user, "Customer");
        var roles = await _userManager.GetRolesAsync(user);
        var token = await _jwtService.GenerateTokenAsync(
            user.Id,
            user.Email!,
            user.FullName,
            roles);
        
        return new AuthResponse
        {
            Token = token,
            Email = user.Email!,
            FullName = user.FullName,
            Roles = roles,
            ExpiresAt = DateTime.UtcNow.AddHours(1)
        };

    }

    public async Task<AuthResponse> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
            throw new Exception("Invalid email or password.");

        var result = await _signInManager.CheckPasswordSignInAsync(
            user,
            password,
            false);

        if (!result.Succeeded)
            throw new Exception("Invalid email or password.");

        var roles = await _userManager.GetRolesAsync(user);

        var token = await _jwtService.GenerateTokenAsync(
            user.Id,
            user.Email!,
            user.FullName,
            roles);

        return new AuthResponse
        {
            Token = token,
            Email = user.Email!,
            FullName = user.FullName,
            Roles = roles,
            ExpiresAt = DateTime.UtcNow.AddHours(1)
        };
    }
}