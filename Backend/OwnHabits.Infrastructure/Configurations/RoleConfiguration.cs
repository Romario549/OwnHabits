using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        
        // НЕ настраиваем UserRoles и RoleClaims здесь
        // Identity уже сделал это
    }
}