using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OwnHabits.Application.Interfaces;
using OwnHabits.Domain.Models.User;
using System.Security.Claims;
using OwnHabits.Domain.Constants;

namespace OwnHabits.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExternalAuthController : ControllerBase
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;
    private readonly ILogger<ExternalAuthController> _logger;
    private readonly IRoleService _roleService;

    public ExternalAuthController(
        SignInManager<User> signInManager,
        UserManager<User> userManager,
        IUserService userService,
        IRoleService roleService,
        ILogger<ExternalAuthController> logger)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _userService = userService;
        _roleService = roleService;
        _logger = logger;
    }

    [HttpGet("google-login")]
    public IActionResult GoogleLogin()
    {
        _logger.LogInformation("Starting Google login process");
        
        var redirectUrl = Url.Action(nameof(GoogleCallback), "ExternalAuth", null, Request.Scheme);
        _logger.LogInformation($"Redirect URL: {redirectUrl}");
        
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(
            GoogleDefaults.AuthenticationScheme, 
            redirectUrl);
        
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("google-callback")]
    public async Task<IActionResult> GoogleCallback()
    {
        try
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return Redirect($"http://localhost:5173/login?error={Uri.EscapeDataString("External login info is null")}");
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            
            // Пытаемся войти через существующий Google аккаунт
            var signInResult = await _signInManager.ExternalLoginSignInAsync(
                info.LoginProvider, 
                info.ProviderKey, 
                isPersistent: true,
                bypassTwoFactor: true);

            User user = null;
            
            if (signInResult.Succeeded)
            {
                user = await _userManager.FindByEmailAsync(email);
            }
            else
            {
                var registerResult = await _userService.RegisterWithGoogleAsync(info);
                user = await _userManager.FindByEmailAsync(registerResult.Email);
                
                if (user != null)
                {
                    await _signInManager.SignInAsync(user, isPersistent: true);
                }
            }

            if (user != null)
            {
                var userData = new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.CompletedGoals,
                    user.Grade
                };
                
                var userJson = System.Text.Json.JsonSerializer.Serialize(userData);
                var encodedUser = Uri.EscapeDataString(userJson);
                
                // ВАЖНО: передаем и email, и user
                return Redirect($"http://localhost:5173/oauth-callback?user={encodedUser}&email={Uri.EscapeDataString(email)}");
            }

            return Redirect($"http://localhost:5173/login?error={Uri.EscapeDataString("Failed to get user")}");
        }
        catch (Exception ex)
        {
            return Redirect($"http://localhost:5173/login?error={Uri.EscapeDataString(ex.Message)}");
        }
    }
        
    
    
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok(new { message = "Logged out successfully" });
    }

    [HttpGet("user-info")]
    public async Task<IActionResult> GetUserInfo()
    {
        if (User.Identity?.IsAuthenticated != true)
        {
            return Unauthorized(new { error = "Not authenticated" });
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound(new { error = "User not found" });
        }

        return Ok(new
        {
            user.Id,
            user.UserName,
            user.Email
        });
    }
}