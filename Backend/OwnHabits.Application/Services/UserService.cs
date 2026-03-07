using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OwnHabits.Application.Dtos.User;
using OwnHabits.Application.Interfaces;
using OwnHabits.Domain.Constants;
using OwnHabits.Domain.Interfaces;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Application.Services;

public class UserService(
    SignInManager<User> signInManager,
    IUserRepository userRepository,
    IRoleService roleService) : IUserService
{
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IRoleService _roleService = roleService;

    
    public async Task<AuthResult> LoginAsync(LoginDto loginDto)
    {
        var user = await _userRepository.GetByEmailAsync(loginDto.Email);
        if (user == null) 
            throw new ArgumentException("Пользователь с такой почтой не существует!");
    
        var result = await _signInManager
            .PasswordSignInAsync(
                user, 
                loginDto.Password, 
                true,
                false);
    
        if (!result.Succeeded)
            throw new ArgumentException($"Не удалось войти в систему!");
    
        // Явно вызываем SignInAsync для установки куки
        await _signInManager.SignInAsync(user, isPersistent: true);
    
        var userRoles = await _roleService.GetUserRolesAsync(user.Id);

        return new AuthResult(
            DateTime.UtcNow.AddMinutes(60),
            user.Email,
            user.Id,
            userRoles
        );
    }

    public async Task<AuthResult> RegisterAsync(RegistrationDto registerDto)
    {
        if (await _userRepository.EmailExistsAsync(registerDto.Email))
            throw new ArgumentException($"Пользователь с почтой {registerDto.Email} уже существует!");

        if (registerDto.Password != registerDto.ConfirmPassword)
            throw new ArgumentException("Пароли не совпадают!");
        
        var user = new User()
        {
            Email = registerDto.Email,
            UserName = registerDto.UserName,
        };
        
        var result = await _userRepository.CreateUserAsync(user, registerDto.Password);
        if (!result.Succeeded)
            throw new ArgumentException($"Не удалось создать пользователя!");
        
        await _roleService.AssignRoleToUserAsync(user.Id, Roles.Users);

        var userRoles = await _roleService.GetUserRolesAsync(user.Id);
        
        return new AuthResult(
            DateTime.UtcNow.AddMinutes(60),
            user.Email,
            user.Id,
            userRoles
        );
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _userRepository.GetByEmailWithAllAbilities(email);
    }

    public async Task<AuthResult> LoginWithGoogleAsync(ExternalLoginInfo info)
    {
        var user = await _userRepository.GetByLoginAsync(info.LoginProvider, info.ProviderKey);
        if (user == null)
            return null; 
    
        await _signInManager.SignInAsync(user, false);
        var userRoles = await _roleService.GetUserRolesAsync(user.Id);
    
        return new AuthResult(
            DateTime.UtcNow.AddMinutes(60),
            user.Email,
            user.Id,
            userRoles
        );
    }

    public async Task<AuthResult> RegisterWithGoogleAsync(ExternalLoginInfo info)
    {
        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        var name = info.Principal.FindFirstValue(ClaimTypes.Name);    
        
        var existingUser = await _userRepository.GetByEmailAsync(email);

        if (existingUser != null)
        {
            // Добавляем ему Google логин
            await _userRepository.AddLoginAsync(existingUser, info);
            var existingUserRoles = await _roleService.GetUserRolesAsync(existingUser.Id);

            return new AuthResult(
                DateTime.UtcNow.AddMinutes(60),
                existingUser.Email,
                existingUser.Id,
                existingUserRoles
            );
        }

        var user = new User
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };

        var result = await _userRepository.CreateUserAsync(user);
        if (!result.Succeeded)
            throw new ArgumentException($"Не удалось создать пользователя!");

        await _userRepository.AddLoginAsync(user, info);
        
        await _roleService.AssignRoleToUserAsync(user.Id, Roles.Users);
        
        var userRoles = await _roleService.GetUserRolesAsync(user.Id);
        return new AuthResult(
            DateTime.UtcNow.AddMinutes(60),
            user.Email,
            user.Id,
            userRoles
        );
    }
}