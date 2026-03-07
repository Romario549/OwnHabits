using Microsoft.AspNetCore.Identity;
using OwnHabits.Application.Interfaces;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Application.Services;

public class RoleService(
	UserManager<User> userManager, 
	RoleManager<Role> roleManager) : IRoleService
{
	private readonly UserManager<User> _userManager = userManager;
	private readonly RoleManager<Role> _roleManager = roleManager;

	public async Task<bool> RoleExistsAsync(string roleName) =>
		await _roleManager.RoleExistsAsync(roleName);

	public async Task CreateRoleAsync(string roleName, string? description = null)
	{
		if(!await _roleManager.RoleExistsAsync(roleName))
		{
			var role = new Role
			{
				Name = roleName,
				NormalizedName = roleName.ToUpper(),
				Description = description

			};
			await _roleManager.CreateAsync(role);
		}	
	}
	public async Task<IEnumerable<string>> GetUserRolesAsync(Guid userId)
	{
		var user = await _userManager.FindByIdAsync(userId.ToString());
		return user != null ? await _userManager.GetRolesAsync(user) : [];
	}

	public async Task AssignRoleToUserAsync(Guid userId, string roleName)
	{
		var user = await _userManager.FindByIdAsync(userId.ToString());
		if (user != null)
		{
			await _userManager.AddToRoleAsync(user, roleName);
		}
	}

	public async Task RemoveRoleFromUserAsync(Guid userId, string roleName)
	{
		var user = await _userManager.FindByIdAsync(userId.ToString());
		if (user != null)
		{
			await _userManager.RemoveFromRoleAsync(user, roleName);
			
		}
	}

}