using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnHabits.Domain.Models;

namespace OwnHabits.Infrastructure.Configurations;

public class AchievementConfiguration: IEntityTypeConfiguration<Achievement>
{
    public void Configure(EntityTypeBuilder<Achievement> builder)
    {
        builder.ToTable("Achievements");
        builder.HasKey(x => x.Id);
        builder.HasOne(c=>c.CharacteristicToUpgrade)
            .WithMany(c=>c.CompletedAchievements)
            .HasForeignKey(c=>c.CharacteristicId);
    }
}