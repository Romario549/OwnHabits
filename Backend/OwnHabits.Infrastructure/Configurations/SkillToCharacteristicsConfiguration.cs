using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnHabits.Domain.Models;

namespace OwnHabits.Infrastructure.Configurations;

public class SkillToCharacteristicsConfiguration : IEntityTypeConfiguration<SkillToCharacteristics>
{
    public void Configure(EntityTypeBuilder<SkillToCharacteristics> builder)
    {
        builder.ToTable("SkillToCharacteristics");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.SkillId)
            .IsRequired();

        builder.Property(x => x.CharacteristicId)
            .IsRequired();

        builder.HasOne(x => x.Skill)
            .WithMany(s => s.UpgradableCharacteristics)
            .HasForeignKey(x => x.SkillId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Characteristic)
            .WithMany(c => c.RequiredSkills)
            .HasForeignKey(x => x.CharacteristicId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}