using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OwnHabits.Application.Interfaces;
using OwnHabits.Application.Services;

namespace OwnHabits.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IGoalService, GoalService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        
        return services;
        
    }
}