using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnHabits.Domain.Models;

namespace OwnHabits.Infrastructure.Configurations;

public class GoalsToSkillsConfiguration : IEntityTypeConfiguration<GoalsToSkills>
{
    public void Configure(EntityTypeBuilder<GoalsToSkills> builder)
    {
        builder.ToTable("GoalsToSkills");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.SkillId)
            .IsRequired();
            
        builder.Property(x => x.GoalId)
            .IsRequired();
        
        builder.HasOne(x => x.Skill)
            .WithMany(s => s.ExperiencedGoals) 
            .HasForeignKey(x => x.SkillId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Goal)
            .WithMany(g => g.UpgradableSkills) 
            .HasForeignKey(x => x.GoalId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}