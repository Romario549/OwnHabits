using Microsoft.EntityFrameworkCore;
using OwnHabits.Domain.Models;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Infrastructure;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Characteristic> Characteristics { get; set; }
    public DbSet<Achievement> Achievements { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}