namespace OwnHabits.Application.Interfaces;

public interface IRoleService
{
    Task<bool> RoleExistsAsync(string roleName);
    Task CreateRoleAsync(string roleName, string? description = null);
    Task AssignRoleToUserAsync(Guid userId, string roleName);
    Task RemoveRoleFromUserAsync(Guid userId, string roleName);
    Task<IEnumerable<string>> GetUserRolesAsync(Guid userId);
}