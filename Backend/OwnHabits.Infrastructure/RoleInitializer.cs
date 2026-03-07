using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OwnHabits.Domain.Constants;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Infrastructure;

public static class RoleInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

        var roles = new[]
        {
            new { Name = Roles.Admins, Description = "Администраторы" },
            new { Name = Roles.Users, Description = "Пользователи" }
        };

        foreach (var role in roles) 
        {
            if (!await roleManager.RoleExistsAsync(role.Name))
            {
                await roleManager.CreateAsync(new Role
                {
                    Name = role.Name,
                    NormalizedName = role.Name.ToUpper(),
                    Description = role.Description
                });
            }
        }
    }
}
