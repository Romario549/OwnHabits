using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;

namespace OwnHabits.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddExtensions(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddControllersWithViews();

        // Добавляем CORS
        services.AddCors(options =>
        {
            options.AddPolicy("FrontendPolicy", policy =>
            {
                policy.WithOrigins(
                        "http://localhost:5173"  
                    )
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });

        services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(@"./keys")); 
    
        // НЕ добавляем схемы заново, только настраиваем существующие
        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = ".OwnHabits.Auth";
            options.Cookie.HttpOnly = true;
            options.Cookie.SameSite = SameSiteMode.Lax;
            options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            options.Cookie.MaxAge = TimeSpan.FromDays(7);
            options.ExpireTimeSpan = TimeSpan.FromDays(7);
            options.SlidingExpiration = true;
            options.Cookie.Domain = null;
            
            // Настройки для API
            options.Events = new CookieAuthenticationEvents
            {
                OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                },
                OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = 403;
                    return Task.CompletedTask;
                }
            };
        });

        // Добавляем только Google аутентификацию, без указания схем
        services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.ClientId = configuration["Authentication:Google:ClientId"];
                options.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                options.SignInScheme = IdentityConstants.ExternalScheme;
                options.CallbackPath = "/signin-google";
                
                options.Scope.Add("profile");
                options.Scope.Add("email");
                options.Scope.Add("openid");
                
                options.CorrelationCookie.SameSite = SameSiteMode.Lax;
                options.CorrelationCookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                
                options.SaveTokens = true;
            });

        services.AddAuthorization();
    
        return services;
    }
}