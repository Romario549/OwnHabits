using Microsoft.AspNetCore.Identity;
using OwnHabits.Application.Dtos.User;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Application.Interfaces;

public interface IUserService
{
    Task<AuthResult> RegisterAsync(RegistrationDto registerDto);
    Task<AuthResult> LoginAsync(LoginDto loginDto);
    
    Task<User> GetUserByEmailAsync(string email);
    
    Task<AuthResult> LoginWithGoogleAsync(ExternalLoginInfo info);
    Task<AuthResult> RegisterWithGoogleAsync(ExternalLoginInfo info);
}