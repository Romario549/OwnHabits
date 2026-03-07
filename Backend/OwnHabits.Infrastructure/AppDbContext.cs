using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OwnHabits.Domain.Models;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Infrastructure;

public class AppDbContext: IdentityDbContext<User, Role, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public AppDbContext()
    {
    }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Characteristic> Characteristics { get; set; }
    public DbSet<Achievement> Achievements { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}