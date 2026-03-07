using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OwnHabits.Application.Interfaces;
using OwnHabits.Domain.Constants;

namespace OwnHabits.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = Roles.Admins)]
public class RolesController(IRoleService roleService) : ControllerBase
{
    private readonly IRoleService _roleService = roleService;
    
    [HttpPost("assign")]
    public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto dto)
    {
        await _roleService.AssignRoleToUserAsync(dto.UserId, dto.RoleName);
        return Ok(new { Message = $"Роль {dto.RoleName} присвоена" });
    }
    
    [HttpPost("remove")]
    public async Task<IActionResult> RemoveRole([FromBody] RemoveRoleDto dto)
    {
        await _roleService.RemoveRoleFromUserAsync(dto.UserId, dto.RoleName);
        return Ok(new { Message = $"Роль {dto.RoleName} удалена" });
    }
    
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserRoles(Guid userId)
    {
        var roles = await _roleService.GetUserRolesAsync(userId);
        return Ok(roles);
    }
}

public record AssignRoleDto(Guid UserId, string RoleName);
public record RemoveRoleDto(Guid UserId, string RoleName);