using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnHabits.Domain.Models;

namespace OwnHabits.Infrastructure.Configurations;

public class SkillConfiguration: IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.ToTable("Skills");
        builder.HasKey(s => s.Id);
        builder.HasMany(s => s.ExperiencedGoals)
            .WithOne(g => g.Skill)
            .HasForeignKey(g => g.SkillId);
        builder.HasMany(s => s.UpgradableCharacteristics)
            .WithOne(g => g.Skill)
            .HasForeignKey(g => g.SkillId);
        builder.HasMany(s=>s.UserSkills)
            .WithOne(g=>g.Skill)
            .HasForeignKey(g=>g.SkillId);
    }
}