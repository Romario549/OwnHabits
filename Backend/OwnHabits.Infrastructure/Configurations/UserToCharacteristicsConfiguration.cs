using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Infrastructure.Configurations;

public class UserToCharacteristicsConfiguration : IEntityTypeConfiguration<UserToCharacteristics>
{
    public void Configure(EntityTypeBuilder<UserToCharacteristics> builder)
    {
        builder.ToTable("UserToCharacteristics");
        
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.User)
            .WithMany(u => u.Characteristics) // Важно: указываем навигационное свойство
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Characteristic)
            .WithMany(c => c.UserCharacteristics) // Важно: указываем навигационное свойство
            .HasForeignKey(x => x.CharacteristicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}