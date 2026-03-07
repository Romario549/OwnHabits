using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OwnHabits.Application.Dtos.User;
using OwnHabits.Application.Interfaces;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(
        IUserService userService,
        SignInManager<User> signInManager)
    {
        _userService = userService;
    }
    
    [HttpPost("registration")]
    public async Task<IActionResult> Register([FromBody] RegistrationDto registrationDto)
    {
        var result = await _userService.RegisterAsync(registrationDto);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var result = await _userService.LoginAsync(loginDto);
        return Ok(result);
    }

    [HttpGet("info/{email}")]
    public async Task<User> GetUserInfo(string email)
    {
        return await _userService.GetUserByEmailAsync(email);
    }
    
}