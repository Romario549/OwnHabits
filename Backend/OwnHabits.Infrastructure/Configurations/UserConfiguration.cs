using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        // Identity уже настроил ключ, но мы можем добавить индексы
        builder.HasIndex(u => u.Email).IsUnique();
        
        // Ваши кастомные связи (НЕ трогаем Identity связи)
        builder.HasMany(u => u.Goals)
            .WithOne(g => g.User)
            .HasForeignKey(g => g.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(u => u.Characteristics)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(u => u.Skills)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // НЕ настраиваем UserRoles, Logins, Claims, Tokens здесь
        // Identity уже сделал это
    }
}