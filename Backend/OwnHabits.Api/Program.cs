using OwnHabits.Api;
using OwnHabits.Application;
using OwnHabits.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Добавляем логирование
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddExtensions(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    await RoleInitializer.InitializeAsync(scope.ServiceProvider);
}

app.UseRouting();
app.UseCors("FrontendPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();